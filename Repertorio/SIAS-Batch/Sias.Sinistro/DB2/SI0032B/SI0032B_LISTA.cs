using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0032B
{
    public class SI0032B_LISTA : QueryBasis<SI0032B_LISTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0032B_LISTA() { IsCursor = true; }

        public SI0032B_LISTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIANAROD_COD_USUARIO { get; set; }
        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_EVENTO { get; set; }
        public string SISINACO_DATA_MOVTO_SINIACO { get; set; }
        public string SIMOVSIN_NATUREZA_SINISTRO { get; set; }
        public string SIMOVSIN_NOME_SEGURADO { get; set; }
        public string SINISMES_NUM_IRB { get; set; }

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


        public override SI0032B_LISTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0032B_LISTA();
            var i = 0;

            dta.SIANAROD_COD_USUARIO = result[i++].Value?.ToString();
            dta.SISINACO_COD_FONTE = result[i++].Value?.ToString();
            dta.SISINACO_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SISINACO_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SISINACO_COD_EVENTO = result[i++].Value?.ToString();
            dta.SISINACO_DATA_MOVTO_SINIACO = result[i++].Value?.ToString();
            dta.SIMOVSIN_NATUREZA_SINISTRO = result[i++].Value?.ToString();
            dta.SIMOVSIN_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_IRB = result[i++].Value?.ToString();

            return dta;
        }

    }
}