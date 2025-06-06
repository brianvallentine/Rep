using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0863B
{
    public class SI0863B_CARTA_AVISO : QueryBasis<SI0863B_CARTA_AVISO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0863B_CARTA_AVISO() { IsCursor = true; }

        public SI0863B_CARTA_AVISO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINBENCB_NUM_APOLICE { get; set; }
        public string SINBENCB_NUM_SINISTRO { get; set; }
        public string SINBENCB_NUM_BILHETE { get; set; }
        public string SINBENCB_OCORR_HISTORICO { get; set; }
        public string SINBENCB_DTMOVTO { get; set; }
        public string SINBENCB_NOME_BENEFICIARIO { get; set; }
        public string SINBENCB_ENDERECO { get; set; }
        public string SINBENCB_BAIRRO { get; set; }
        public string SINBENCB_CIDADE { get; set; }
        public string SINBENCB_SIGLA_UF { get; set; }
        public string SINBENCB_CEP { get; set; }
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


        public override SI0863B_CARTA_AVISO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0863B_CARTA_AVISO();
            var i = 0;

            dta.SINBENCB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINBENCB_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.SINBENCB_NUM_BILHETE = result[i++].Value?.ToString();
            dta.SINBENCB_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINBENCB_DTMOVTO = result[i++].Value?.ToString();
            dta.SINBENCB_NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.SINBENCB_ENDERECO = result[i++].Value?.ToString();
            dta.SINBENCB_BAIRRO = result[i++].Value?.ToString();
            dta.SINBENCB_CIDADE = result[i++].Value?.ToString();
            dta.SINBENCB_SIGLA_UF = result[i++].Value?.ToString();
            dta.SINBENCB_CEP = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}