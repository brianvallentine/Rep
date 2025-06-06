using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9106B
{
    public class SI9106B_C01_SIARDEVC : QueryBasis<SI9106B_C01_SIARDEVC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI9106B_C01_SIARDEVC() { IsCursor = true; }

        public SI9106B_C01_SIARDEVC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIARDEVC_NOM_ARQUIVO { get; set; }
        public string SIARDEVC_SEQ_GERACAO { get; set; }
        public string SIARDEVC_TIPO_REGISTRO { get; set; }
        public string SIARDEVC_SEQ_REGISTRO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_NUM_SINISTRO_VC { get; set; }
        public string SIARDEVC_NUM_EXPEDIENTE_VC { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string SIARDEVC_NUM_ENDOSSO { get; set; }
        public string SIARDEVC_NUM_ITEM { get; set; }
        public string SIARDEVC_COD_COBERTURA { get; set; }
        public string SIARDEVC_DATA_OCORRENCIA { get; set; }
        public string SIARDEVC_VAL_TOT_MOVIMENTO { get; set; }

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


        public override SI9106B_C01_SIARDEVC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI9106B_C01_SIARDEVC();
            var i = 0;

            dta.SIARDEVC_NOM_ARQUIVO = result[i++].Value?.ToString();
            dta.SIARDEVC_SEQ_GERACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_SINISTRO_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_EXPEDIENTE_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_ITEM = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_TOT_MOVIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}