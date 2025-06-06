using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0681B
{
    public class VA0681B_CPROPOSTA : QueryBasis<VA0681B_CPROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0681B_CPROPOSTA() { IsCursor = true; }

        public VA0681B_CPROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FONTES_NOME_FONTE { get; set; }
        public string ESCRINEG_COD_ESCNEG { get; set; }
        public string ESCRINEG_NOME_ABREV_ESCNEG { get; set; }
        public string VIND_NOM_ESCNEG { get; set; }
        public string AGENCIAS_COD_AGENCIA { get; set; }
        public string AGENCIAS_NOME_AGENCIA { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string PROPOVA_COD_USUARIO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

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


        public override VA0681B_CPROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0681B_CPROPOSTA();
            var i = 0;

            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            dta.ESCRINEG_COD_ESCNEG = result[i++].Value?.ToString();
            dta.ESCRINEG_NOME_ABREV_ESCNEG = result[i++].Value?.ToString();
            dta.VIND_NOM_ESCNEG = string.IsNullOrWhiteSpace(dta.ESCRINEG_NOME_ABREV_ESCNEG) ? "-1" : "0";
            dta.AGENCIAS_COD_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCIAS_NOME_AGENCIA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_COD_USUARIO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}