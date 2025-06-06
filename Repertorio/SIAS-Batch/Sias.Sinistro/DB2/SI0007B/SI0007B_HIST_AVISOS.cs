using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0007B
{
    public class SI0007B_HIST_AVISOS : QueryBasis<SI0007B_HIST_AVISOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0007B_HIST_AVISOS() { IsCursor = true; }

        public SI0007B_HIST_AVISOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string LOTERI01_SIGLA_UF { get; set; }
        public string LOTERI01_ENDERECO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SIMOLOT1_VALOR_INFORMADO { get; set; }
        public string SIMOLOT1_QTD_PORTADORES { get; set; }
        public string SIMOLOT1_IND_ADIANTAMENTO { get; set; }

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


        public override SI0007B_HIST_AVISOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0007B_HIST_AVISOS();
            var i = 0;

            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.LOTERI01_SIGLA_UF = result[i++].Value?.ToString();
            dta.LOTERI01_ENDERECO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SIMOLOT1_VALOR_INFORMADO = result[i++].Value?.ToString();
            dta.SIMOLOT1_QTD_PORTADORES = result[i++].Value?.ToString();
            dta.SIMOLOT1_IND_ADIANTAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}