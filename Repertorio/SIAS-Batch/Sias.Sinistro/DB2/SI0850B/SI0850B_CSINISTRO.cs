using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0850B
{
    public class SI0850B_CSINISTRO : QueryBasis<SI0850B_CSINISTRO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0850B_CSINISTRO() { IsCursor = true; }

        public SI0850B_CSINISTRO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_DATA_TECNICA { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string DIAS_PENDENTES { get; set; }
        public string DCLCLIENTES_NOME_RAZAO { get; set; }
        public string WS_DATE_AMP { get; set; }

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


        public override SI0850B_CSINISTRO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0850B_CSINISTRO();
            var i = 0;

            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_TECNICA = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.DIAS_PENDENTES = result[i++].Value?.ToString();
            dta.DCLCLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.WS_DATE_AMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}