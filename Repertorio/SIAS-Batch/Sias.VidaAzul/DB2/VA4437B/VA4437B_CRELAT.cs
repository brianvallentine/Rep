using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class VA4437B_CRELAT : QueryBasis<VA4437B_CRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA4437B_CRELAT() { IsCursor = true; }

        public VA4437B_CRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_TIMESTAMP { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_IDADE { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_FAIXA_RENDA_IND { get; set; }
        public string VIND_RENDA_IND { get; set; }
        public string PROPOVA_FAIXA_RENDA_FAM { get; set; }
        public string VIND_RENDA_FAM { get; set; }
        public string PRODUVG_CODRELAT { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string PRODUTO_NUM_PROCESSO_SUSEP { get; set; }

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


        public override VA4437B_CRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA4437B_CRELAT();
            var i = 0;

            dta.RELATORI_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.RELATORI_TIMESTAMP = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_IDE_SEXO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_IDADE = result[i++].Value?.ToString();
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PROPOVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_RENDA_IND = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_RENDA_FAM = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_FAM) ? "-1" : "0";
            dta.PRODUVG_CODRELAT = result[i++].Value?.ToString();
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_NUM_PROCESSO_SUSEP = result[i++].Value?.ToString();

            return dta;
        }

    }
}