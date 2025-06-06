using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0530S
{
    public class GE0530S_C002 : QueryBasis<GE0530S_C002>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0530S_C002() { IsCursor = true; }

        public GE0530S_C002(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE530_SEQ_PEPS { get; set; }
        public string GE530_DTA_INIVIG_PEPS { get; set; }
        public string GE530_DTA_FIMVIG_PEPS { get; set; }
        public string GE530_COD_TP_PEPS { get; set; }
        public string GE530_COD_PEPS_EXTERNO { get; set; }
        public string GE530_COD_PEPS_RELACIONADO { get; set; }
        public string GE530_NUM_CPF_CNPJ { get; set; }
        public string GE530_NOM_PEPS { get; set; }
        public string GE530_COD_ORGAO_PESS_PEPS { get; set; }
        public string GE530_NOM_ORGAO_PEPS { get; set; }
        public string GE530_COD_CARGO { get; set; }
        public string GE530_NOM_CARGO { get; set; }
        public string GE530_COD_COAF { get; set; }
        public string GE530_IND_SEXO { get; set; }
        public string GE530_NOM_LOGRADOURO { get; set; }
        public string GE530_DES_LOGRADOURO { get; set; }
        public string GE530_DES_COMPLEMENTO { get; set; }
        public string GE530_NOM_BAIRRO { get; set; }
        public string GE530_COD_CEP { get; set; }
        public string GE530_NOM_MUNICIPIO { get; set; }
        public string GE530_COD_UF { get; set; }
        public string GE530_DTA_NOMEACAO { get; set; }
        public string GE530_DTA_EXONERACAO { get; set; }
        public string GE530_NOM_MUNICIPIO_ORGAO { get; set; }
        public string GE530_COD_UF_ORGAO { get; set; }
        public string GE530_COD_USUARIO { get; set; }
        public string GE530_NOM_PROGRAMA { get; set; }
        public string GE530_DTH_CADASTRAMENTO { get; set; }

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


        public override GE0530S_C002 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0530S_C002();
            var i = 0;

            dta.GE530_SEQ_PEPS = result[i++].Value?.ToString();
            dta.GE530_DTA_INIVIG_PEPS = result[i++].Value?.ToString();
            dta.GE530_DTA_FIMVIG_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_TP_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_PEPS_EXTERNO = result[i++].Value?.ToString();
            dta.GE530_COD_PEPS_RELACIONADO = result[i++].Value?.ToString();
            dta.GE530_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.GE530_NOM_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_ORGAO_PESS_PEPS = result[i++].Value?.ToString();
            dta.GE530_NOM_ORGAO_PEPS = result[i++].Value?.ToString();
            dta.GE530_COD_CARGO = result[i++].Value?.ToString();
            dta.GE530_NOM_CARGO = result[i++].Value?.ToString();
            dta.GE530_COD_COAF = result[i++].Value?.ToString();
            dta.GE530_IND_SEXO = result[i++].Value?.ToString();
            dta.GE530_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.GE530_DES_LOGRADOURO = result[i++].Value?.ToString();
            dta.GE530_DES_COMPLEMENTO = result[i++].Value?.ToString();
            dta.GE530_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.GE530_COD_CEP = result[i++].Value?.ToString();
            dta.GE530_NOM_MUNICIPIO = result[i++].Value?.ToString();
            dta.GE530_COD_UF = result[i++].Value?.ToString();
            dta.GE530_DTA_NOMEACAO = result[i++].Value?.ToString();
            dta.GE530_DTA_EXONERACAO = result[i++].Value?.ToString();
            dta.GE530_NOM_MUNICIPIO_ORGAO = result[i++].Value?.ToString();
            dta.GE530_COD_UF_ORGAO = result[i++].Value?.ToString();
            dta.GE530_COD_USUARIO = result[i++].Value?.ToString();
            dta.GE530_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.GE530_DTH_CADASTRAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}