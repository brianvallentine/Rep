using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0857B
{
    public class SI0857B_LISTA : QueryBasis<SI0857B_LISTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0857B_LISTA() { IsCursor = true; }

        public SI0857B_LISTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIANAROD_COD_USUARIO { get; set; }
        public string SIDOCPAR_COD_TIPO_CARTA { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string SIDOCACO_COD_DOCUMENTO { get; set; }
        public string GEDOCTIP_DESCR_DOCUMENTO { get; set; }
        public string SIMOVSIN_NATUREZA_SINISTRO { get; set; }
        public string SIMOVSIN_NOME_SEGURADO { get; set; }
        public string SIMOVSIN_COD_GIAFI { get; set; }
        public string SIMOVSIN_NUM_CONTR_ESTIP { get; set; }
        public string GERECADE_COD_DESTINATARIO { get; set; }
        public string SIDOCACO_NUM_CARTA { get; set; }
        public string SIMOVSIN_COD_SUBESTIPULANTE { get; set; }

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


        public override SI0857B_LISTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0857B_LISTA();
            var i = 0;

            dta.SIANAROD_COD_USUARIO = result[i++].Value?.ToString();
            dta.SIDOCPAR_COD_TIPO_CARTA = result[i++].Value?.ToString();
            dta.SIDOCACO_COD_FONTE = result[i++].Value?.ToString();
            dta.SIDOCACO_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SIDOCACO_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SIDOCACO_DATA_MOVTO_DOCACO = result[i++].Value?.ToString();
            dta.SIDOCACO_COD_DOCUMENTO = result[i++].Value?.ToString();
            dta.GEDOCTIP_DESCR_DOCUMENTO = result[i++].Value?.ToString();
            dta.SIMOVSIN_NATUREZA_SINISTRO = result[i++].Value?.ToString();
            dta.SIMOVSIN_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_GIAFI = result[i++].Value?.ToString();
            dta.SIMOVSIN_NUM_CONTR_ESTIP = result[i++].Value?.ToString();
            dta.GERECADE_COD_DESTINATARIO = result[i++].Value?.ToString();
            dta.SIDOCACO_NUM_CARTA = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_SUBESTIPULANTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}