using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class VA0600B_ENDERECOS : QueryBasis<VA0600B_ENDERECOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0600B_ENDERECOS() { IsCursor = true; }

        public VA0600B_ENDERECOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPESSOA_ENDERECO_OCORR_ENDERECO { get; set; }
        public string DCLPESSOA_ENDERECO_COD_PESSOA { get; set; }
        public string DCLPESSOA_ENDERECO_ENDERECO { get; set; }
        public string DCLPESSOA_ENDERECO_TIPO_ENDER { get; set; }
        public string DCLPESSOA_ENDERECO_BAIRRO { get; set; }
        public string DCLPESSOA_ENDERECO_CEP { get; set; }
        public string DCLPESSOA_ENDERECO_CIDADE { get; set; }
        public string DCLPESSOA_ENDERECO_SIGLA_UF { get; set; }
        public string DCLPESSOA_ENDERECO_SITUACAO_ENDERECO { get; set; }

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


        public override VA0600B_ENDERECOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0600B_ENDERECOS();
            var i = 0;

            dta.DCLPESSOA_ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_COD_PESSOA = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_TIPO_ENDER = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_CEP = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_SITUACAO_ENDERECO = result[i++].Value?.ToString();

            return dta;
        }

    }
}