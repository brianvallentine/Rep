using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class SI0874B_CTRAB : QueryBasis<SI0874B_CTRAB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0874B_CTRAB() { IsCursor = true; }

        public SI0874B_CTRAB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_NUM_ENDOSSO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_TIPO_SEGURADO { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_IRB { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_HORA_OPERACAO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_DATA_LIM_CORRECAO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }

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


        public override SI0874B_CTRAB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0874B_CTRAB();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.SINISMES_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SINISMES_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISMES_NUM_IRB = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_HORA_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_LIM_CORRECAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();

            return dta;
        }

    }
}