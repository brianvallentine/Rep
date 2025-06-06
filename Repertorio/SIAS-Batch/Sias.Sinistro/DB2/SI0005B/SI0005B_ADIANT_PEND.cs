using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class SI0005B_ADIANT_PEND : QueryBasis<SI0005B_ADIANT_PEND>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0005B_ADIANT_PEND() { IsCursor = true; }

        public SI0005B_ADIANT_PEND(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string HOST_VALOR_AVISADO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SIMOLOT1_VALOR_INFORMADO { get; set; }

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


        public override SI0005B_ADIANT_PEND OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0005B_ADIANT_PEND();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.HOST_VALOR_AVISADO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SIMOLOT1_VALOR_INFORMADO = result[i++].Value?.ToString();

            return dta;
        }

    }
}