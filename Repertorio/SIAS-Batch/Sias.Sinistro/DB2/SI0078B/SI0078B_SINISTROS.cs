using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0078B
{
    public class SI0078B_SINISTROS : QueryBasis<SI0078B_SINISTROS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0078B_SINISTROS() { IsCursor = true; }

        public SI0078B_SINISTROS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINI_NUM_APOL_SINISTRO { get; set; }
        public string SINI_NUM_APOLICE { get; set; }
        public string SINI_NUMIRB { get; set; }
        public string SINI_CODCAU { get; set; }
        public string SINI_DATCMD { get; set; }
        public string SINI_DATORR { get; set; }
        public string SINI_SITUACAO { get; set; }
        public string SINI_RAMO { get; set; }
        public string SINI_OCORHIST { get; set; }
        public string SINI_OPERACAO { get; set; }
        public string SINI_DTMOVTO { get; set; }
        public string SINI_VAL_OPERACAO { get; set; }
        public string SINI_NOMFAV { get; set; }
        public string SINI_CODUSU { get; set; }

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


        public override SI0078B_SINISTROS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0078B_SINISTROS();
            var i = 0;

            dta.SINI_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINI_NUMIRB = result[i++].Value?.ToString();
            dta.SINI_CODCAU = result[i++].Value?.ToString();
            dta.SINI_DATCMD = result[i++].Value?.ToString();
            dta.SINI_DATORR = result[i++].Value?.ToString();
            dta.SINI_SITUACAO = result[i++].Value?.ToString();
            dta.SINI_RAMO = result[i++].Value?.ToString();
            dta.SINI_OCORHIST = result[i++].Value?.ToString();
            dta.SINI_OPERACAO = result[i++].Value?.ToString();
            dta.SINI_DTMOVTO = result[i++].Value?.ToString();
            dta.SINI_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINI_NOMFAV = result[i++].Value?.ToString();
            dta.SINI_CODUSU = result[i++].Value?.ToString();

            return dta;
        }

    }
}