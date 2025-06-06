using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0868B
{
    public class SI0868B_RAMOVG : QueryBasis<SI0868B_RAMOVG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0868B_RAMOVG() { IsCursor = true; }

        public SI0868B_RAMOVG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string HOST_DATA_AVISO_SIAS { get; set; }
        public string HOST_VALOR_AVISO_SIAS { get; set; }

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


        public override SI0868B_RAMOVG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0868B_RAMOVG();
            var i = 0;

            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISMES_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SINISMES_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.HOST_DATA_AVISO_SIAS = result[i++].Value?.ToString();
            dta.HOST_VALOR_AVISO_SIAS = result[i++].Value?.ToString();

            return dta;
        }

    }
}