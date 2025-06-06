using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0181B
{
    public class SI0181B_PRINCIPAL : QueryBasis<SI0181B_PRINCIPAL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0181B_PRINCIPAL() { IsCursor = true; }

        public SI0181B_PRINCIPAL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_HORA_OPERACAO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string USUARIOS_NOME_USUARIO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_NOM_PROGRAMA { get; set; }
        public string ESTRUTUR_NOME_GRUPO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string WHOST_SIT_MOVIMENTO { get; set; }

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


        public override SI0181B_PRINCIPAL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0181B_PRINCIPAL();
            var i = 0;

            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_HORA_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.USUARIOS_NOME_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.ESTRUTUR_NOME_GRUPO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.WHOST_SIT_MOVIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}