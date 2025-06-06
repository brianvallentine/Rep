using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class VP0437B_CRELAT : QueryBasis<VP0437B_CRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0437B_CRELAT() { IsCursor = true; }

        public VP0437B_CRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_IDADE { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string WS_DATA_FIM_CALC { get; set; }
        public string PRODUVG_CODRELAT { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }

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


        public override VP0437B_CRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0437B_CRELAT();
            var i = 0;

            dta.RELATORI_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_IDE_SEXO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_IDADE = result[i++].Value?.ToString();
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.WS_DATA_FIM_CALC = result[i++].Value?.ToString();
            dta.PRODUVG_CODRELAT = result[i++].Value?.ToString();
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();

            return dta;
        }

    }
}