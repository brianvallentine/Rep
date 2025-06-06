using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0891B
{
    public class SI0891B_CTRAB : QueryBasis<SI0891B_CTRAB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0891B_CTRAB() { IsCursor = true; }

        public SI0891B_CTRAB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINIHAB1_OPERACAO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINIHAB1_PONTO_VENDA { get; set; }
        public string SINIHAB1_NUM_CONTRATO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string HOST_SITUACAO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string GEOPERAC_DES_ABREVIADA { get; set; }
        public string HOST_VALOR_HABILIT { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string USUARIOS_COD_USUARIO { get; set; }
        public string USUARIOS_NOME_USUARIO { get; set; }

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


        public override SI0891B_CTRAB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0891B_CTRAB();
            var i = 0;

            dta.SINIHAB1_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINIHAB1_PONTO_VENDA = result[i++].Value?.ToString();
            dta.SINIHAB1_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.HOST_SITUACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_ABREVIADA = result[i++].Value?.ToString();
            dta.HOST_VALOR_HABILIT = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.USUARIOS_COD_USUARIO = result[i++].Value?.ToString();
            dta.USUARIOS_NOME_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}