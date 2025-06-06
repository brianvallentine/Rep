using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9229B
{
    public class SI9229B_CUR01_HIST_MESTRE : QueryBasis<SI9229B_CUR01_HIST_MESTRE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI9229B_CUR01_HIST_MESTRE() { IsCursor = true; }

        public SI9229B_CUR01_HIST_MESTRE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string CAUSACOB_COD_COBERTURA { get; set; }
        public string COBERDES_DESCR_COBERTURA { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_TECNICA { get; set; }
        public string WS_VLR_AVISADO { get; set; }
        public string WS_E_ENDOSSO { get; set; }
        public string ENDOSSOS_DATA_EMISSAO { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string WS_E_PREMATURO { get; set; }

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


        public override SI9229B_CUR01_HIST_MESTRE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI9229B_CUR01_HIST_MESTRE();
            var i = 0;

            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.CAUSACOB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.COBERDES_DESCR_COBERTURA = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_TECNICA = result[i++].Value?.ToString();
            dta.WS_VLR_AVISADO = result[i++].Value?.ToString();
            dta.WS_E_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.WS_E_PREMATURO = result[i++].Value?.ToString();

            return dta;
        }

    }
}