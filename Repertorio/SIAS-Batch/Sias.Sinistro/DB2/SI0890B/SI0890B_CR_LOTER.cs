using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class SI0890B_CR_LOTER : QueryBasis<SI0890B_CR_LOTER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0890B_CR_LOTER() { IsCursor = true; }

        public SI0890B_CR_LOTER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string HOST_DATA_AVISO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string HOST_VALOR_AVISO { get; set; }
        public string SINILT01_COD_CLIENTE { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string SINILT01_COD_COBERTURA { get; set; }
        public string SINISCAU_COD_CAUSA { get; set; }

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


        public override SI0890B_CR_LOTER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0890B_CR_LOTER();
            var i = 0;

            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.HOST_DATA_AVISO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.HOST_VALOR_AVISO = result[i++].Value?.ToString();
            dta.SINILT01_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.SINILT01_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SINISCAU_COD_CAUSA = result[i++].Value?.ToString();

            return dta;
        }

    }
}