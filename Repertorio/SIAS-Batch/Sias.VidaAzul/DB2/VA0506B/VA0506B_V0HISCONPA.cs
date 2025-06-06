using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class VA0506B_V0HISCONPA : QueryBasis<VA0506B_V0HISCONPA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0506B_V0HISCONPA() { IsCursor = true; }

        public VA0506B_V0HISCONPA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_COD_FONTE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }
        public string HISCONPA_DTFATUR { get; set; }
        public string VIND_NULL01 { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }

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


        public override VA0506B_V0HISCONPA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0506B_V0HISCONPA();
            var i = 0;

            dta.HISCONPA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_TITULO = result[i++].Value?.ToString();
            dta.HISCONPA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.HISCONPA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.HISCONPA_COD_FONTE = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_VG = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_AP = result[i++].Value?.ToString();
            dta.HISCONPA_DTFATUR = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.HISCONPA_DTFATUR) ? "-1" : "0";
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}