using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2721B
{
    public class VA2721B_TPROPOVA : QueryBasis<VA2721B_TPROPOVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2721B_TPROPOVA() { IsCursor = true; }

        public VA2721B_TPROPOVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_DATA_MOVIMENTO { get; set; }
        public string WHOST_VLPREMIO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string HISCONPA_DATA_MOVIMENTO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_COD_OPERACAO { get; set; }

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


        public override VA2721B_TPROPOVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2721B_TPROPOVA();
            var i = 0;

            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.WHOST_VLPREMIO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.HISCONPA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_COD_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}