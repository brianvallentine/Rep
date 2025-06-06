using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0848B
{
    public class SI0848B_V0SINISTROS : QueryBasis<SI0848B_V0SINISTROS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0848B_V0SINISTROS() { IsCursor = true; }

        public SI0848B_V0SINISTROS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0SINI_HABIT01_NOME_SEGURADO { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }
        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0HIST_VAL_OPERACAO { get; set; }
        public string V0HIST_DTMOVTO { get; set; }
        public string V0MEST_CODPRODU { get; set; }
        public string V0SINI_HABIT01_OPERACAO { get; set; }
        public string V0SINI_HABIT01_PONTO_VENDA { get; set; }
        public string V0SINI_HABIT01_NUM_CONTRATO { get; set; }
        public string V0SINI_HABIT01_COD_COBERTURA { get; set; }
        public string V0SINI_HABIT01_CGCCPF { get; set; }

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


        public override SI0848B_V0SINISTROS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0848B_V0SINISTROS();
            var i = 0;

            dta.V0SINI_HABIT01_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0HIST_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.V0HIST_DTMOVTO = result[i++].Value?.ToString();
            dta.V0MEST_CODPRODU = result[i++].Value?.ToString();
            dta.V0SINI_HABIT01_OPERACAO = result[i++].Value?.ToString();
            dta.V0SINI_HABIT01_PONTO_VENDA = result[i++].Value?.ToString();
            dta.V0SINI_HABIT01_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.V0SINI_HABIT01_COD_COBERTURA = result[i++].Value?.ToString();
            dta.V0SINI_HABIT01_CGCCPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}