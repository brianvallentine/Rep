using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202B
{
    public class SI0202B_C01_SINISHIS : QueryBasis<SI0202B_C01_SINISHIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0202B_C01_SINISHIS() { IsCursor = true; }

        public SI0202B_C01_SINISHIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINIHAB1_OPERACAO { get; set; }
        public string SINIHAB1_PONTO_VENDA { get; set; }
        public string SINIHAB1_NUM_CONTRATO { get; set; }
        public string SINIHAB1_NOME_SEGURADO { get; set; }
        public string SINIHAB1_COD_CLIENTE { get; set; }
        public string SINIHAB1_CGCCPF { get; set; }
        public string SINISCAU_GRUPO_CAUSAS { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }

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


        public override SI0202B_C01_SINISHIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0202B_C01_SINISHIS();
            var i = 0;

            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINIHAB1_OPERACAO = result[i++].Value?.ToString();
            dta.SINIHAB1_PONTO_VENDA = result[i++].Value?.ToString();
            dta.SINIHAB1_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINIHAB1_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.SINIHAB1_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SINIHAB1_CGCCPF = result[i++].Value?.ToString();
            dta.SINISCAU_GRUPO_CAUSAS = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();

            return dta;
        }

    }
}