using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0218B
{
    public class SI0218B_C01_RELATORI : QueryBasis<SI0218B_C01_RELATORI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0218B_C01_RELATORI() { IsCursor = true; }

        public SI0218B_C01_RELATORI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
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


        public override SI0218B_C01_RELATORI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0218B_C01_RELATORI();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}