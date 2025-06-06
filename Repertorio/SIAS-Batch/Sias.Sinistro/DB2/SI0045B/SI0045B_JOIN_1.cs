using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class SI0045B_JOIN_1 : QueryBasis<SI0045B_JOIN_1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0045B_JOIN_1() { IsCursor = true; }

        public SI0045B_JOIN_1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_NUM_OCORR_SINIACO { get; set; }
        public string SISINACO_COD_EVENTO { get; set; }
        public string SISINACO_DATA_MOVTO_SINIACO { get; set; }
        public string WHOST_DIFERENCA_DIAS { get; set; }
        public string SISINACO_COD_USUARIO { get; set; }
        public string HOST_NUM_CARTA { get; set; }
        public string GECARTA_SEQ_CARTA_REITERA { get; set; }
        public string GECARTA_NUM_CARTA_REITERA { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }

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


        public override SI0045B_JOIN_1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0045B_JOIN_1();
            var i = 0;

            dta.SISINACO_COD_FONTE = result[i++].Value?.ToString();
            dta.SISINACO_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SISINACO_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SISINACO_NUM_OCORR_SINIACO = result[i++].Value?.ToString();
            dta.SISINACO_COD_EVENTO = result[i++].Value?.ToString();
            dta.SISINACO_DATA_MOVTO_SINIACO = result[i++].Value?.ToString();
            dta.WHOST_DIFERENCA_DIAS = result[i++].Value?.ToString();
            dta.SISINACO_COD_USUARIO = result[i++].Value?.ToString();
            dta.HOST_NUM_CARTA = result[i++].Value?.ToString();
            dta.GECARTA_SEQ_CARTA_REITERA = result[i++].Value?.ToString();
            dta.GECARTA_NUM_CARTA_REITERA = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}