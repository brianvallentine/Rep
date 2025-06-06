using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class VA0126B_C01_ENDERECO : QueryBasis<VA0126B_C01_ENDERECO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0126B_C01_ENDERECO() { IsCursor = true; }

        public VA0126B_C01_ENDERECO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ENDERECO_COD_CLIENTE { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_TELEX { get; set; }
        public string ENDERECO_SIT_REGISTRO { get; set; }

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


        public override VA0126B_C01_ENDERECO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0126B_C01_ENDERECO();
            var i = 0;

            dta.ENDERECO_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDERECO_COD_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.ENDERECO_FAX = result[i++].Value?.ToString();
            dta.ENDERECO_TELEX = result[i++].Value?.ToString();
            dta.ENDERECO_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}