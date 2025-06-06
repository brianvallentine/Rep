using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0955B
{
    public class VA0955B_V0SINISTROS : QueryBasis<VA0955B_V0SINISTROS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0955B_V0SINISTROS() { IsCursor = true; }

        public VA0955B_V0SINISTROS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
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


        public override VA0955B_V0SINISTROS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0955B_V0SINISTROS();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}