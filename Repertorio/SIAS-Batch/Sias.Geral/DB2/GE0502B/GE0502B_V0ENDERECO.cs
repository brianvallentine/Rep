using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0502B
{
    public class GE0502B_V0ENDERECO : QueryBasis<GE0502B_V0ENDERECO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0502B_V0ENDERECO() { IsCursor = true; }

        public GE0502B_V0ENDERECO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD007_SEQ_ENDERECO { get; set; }
        public string OD007_DTH_CADASTRAMENTO { get; set; }
        public string OD007_IND_ENDERECO { get; set; }
        public string OD007_STA_ENDERECO { get; set; }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string VIND_NULL02 { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string VIND_NULL03 { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string VIND_NULL05 { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string VIND_NULL06 { get; set; }
        public string OD007_COD_UF { get; set; }
        public string VIND_NULL07 { get; set; }
        public string OD007_STA_CORRESPONDER { get; set; }
        public string OD007_STA_PROPAGANDA { get; set; }

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


        public override GE0502B_V0ENDERECO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0502B_V0ENDERECO();
            var i = 0;

            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD007_SEQ_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD007_IND_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_STA_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.OD007_NOM_LOGRADOURO) ? "-1" : "0";
            dta.OD007_DES_NUM_IMOVEL = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.OD007_DES_NUM_IMOVEL) ? "-1" : "0";
            dta.OD007_DES_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.OD007_DES_COMPL_ENDERECO) ? "-1" : "0";
            dta.OD007_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.OD007_NOM_BAIRRO) ? "-1" : "0";
            dta.OD007_NOM_CIDADE = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.OD007_NOM_CIDADE) ? "-1" : "0";
            dta.OD007_COD_CEP = result[i++].Value?.ToString();
            dta.VIND_NULL06 = string.IsNullOrWhiteSpace(dta.OD007_COD_CEP) ? "-1" : "0";
            dta.OD007_COD_UF = result[i++].Value?.ToString();
            dta.VIND_NULL07 = string.IsNullOrWhiteSpace(dta.OD007_COD_UF) ? "-1" : "0";
            dta.OD007_STA_CORRESPONDER = result[i++].Value?.ToString();
            dta.OD007_STA_PROPAGANDA = result[i++].Value?.ToString();

            return dta;
        }

    }
}