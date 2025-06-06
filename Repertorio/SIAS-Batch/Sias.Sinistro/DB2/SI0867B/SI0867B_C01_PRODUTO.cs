using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0867B
{
    public class SI0867B_C01_PRODUTO : QueryBasis<SI0867B_C01_PRODUTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0867B_C01_PRODUTO() { IsCursor = true; }

        public SI0867B_C01_PRODUTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_TIPO_REGISTRO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISMES_TIPO_SEGURADO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }

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


        public override SI0867B_C01_PRODUTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0867B_C01_PRODUTO();
            var i = 0;

            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}