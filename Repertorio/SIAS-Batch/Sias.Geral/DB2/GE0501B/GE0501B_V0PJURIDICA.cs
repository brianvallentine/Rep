using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0501B
{
    public class GE0501B_V0PJURIDICA : QueryBasis<GE0501B_V0PJURIDICA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0501B_V0PJURIDICA() { IsCursor = true; }

        public GE0501B_V0PJURIDICA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD003_NUM_PESSOA { get; set; }
        public string OD003_NUM_CNPJ { get; set; }
        public string OD003_NUM_FILIAL { get; set; }
        public string OD003_NUM_DV_CNPJ { get; set; }
        public string OD003_NOM_RAZAO_SOCIAL { get; set; }
        public string OD003_STA_PESSOA { get; set; }
        public string OD003_NUM_RAMO_ATIVIDADE { get; set; }
        public string IND_NULL_01 { get; set; }
        public string OD003_DTH_FUNDACAO { get; set; }
        public string IND_NULL_02 { get; set; }
        public string OD003_NOM_FANTASIA { get; set; }
        public string IND_NULL_03 { get; set; }
        public string OD003_NOM_SIGLA_PESSOA { get; set; }
        public string IND_NULL_04 { get; set; }
        public string OD003_NUM_INSC_ESTADUAL { get; set; }
        public string IND_NULL_05 { get; set; }
        public string OD003_NUM_INSC_MUNICIPAL { get; set; }
        public string IND_NULL_06 { get; set; }
        public string OD003_COD_UF { get; set; }
        public string IND_NULL_07 { get; set; }
        public string OD003_NUM_MUNICIPIO { get; set; }
        public string IND_NULL_08 { get; set; }
        public string OD003_COD_CNAE { get; set; }
        public string IND_NULL_09 { get; set; }
        public string OD003_NUM_SOCIOS { get; set; }
        public string IND_NULL_10 { get; set; }
        public string OD003_STA_FRANQUIA { get; set; }
        public string IND_NULL_11 { get; set; }
        public string OD003_IND_FINALIDADE { get; set; }
        public string IND_NULL_12 { get; set; }

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


        public override GE0501B_V0PJURIDICA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0501B_V0PJURIDICA();
            var i = 0;

            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD003_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD003_NUM_CNPJ = result[i++].Value?.ToString();
            dta.OD003_NUM_FILIAL = result[i++].Value?.ToString();
            dta.OD003_NUM_DV_CNPJ = result[i++].Value?.ToString();
            dta.OD003_NOM_RAZAO_SOCIAL = result[i++].Value?.ToString();
            dta.OD003_STA_PESSOA = result[i++].Value?.ToString();
            dta.OD003_NUM_RAMO_ATIVIDADE = result[i++].Value?.ToString();
            dta.IND_NULL_01 = string.IsNullOrWhiteSpace(dta.OD003_NUM_RAMO_ATIVIDADE) ? "-1" : "0";
            dta.OD003_DTH_FUNDACAO = result[i++].Value?.ToString();
            dta.IND_NULL_02 = string.IsNullOrWhiteSpace(dta.OD003_DTH_FUNDACAO) ? "-1" : "0";
            dta.OD003_NOM_FANTASIA = result[i++].Value?.ToString();
            dta.IND_NULL_03 = string.IsNullOrWhiteSpace(dta.OD003_NOM_FANTASIA) ? "-1" : "0";
            dta.OD003_NOM_SIGLA_PESSOA = result[i++].Value?.ToString();
            dta.IND_NULL_04 = string.IsNullOrWhiteSpace(dta.OD003_NOM_SIGLA_PESSOA) ? "-1" : "0";
            dta.OD003_NUM_INSC_ESTADUAL = result[i++].Value?.ToString();
            dta.IND_NULL_05 = string.IsNullOrWhiteSpace(dta.OD003_NUM_INSC_ESTADUAL) ? "-1" : "0";
            dta.OD003_NUM_INSC_MUNICIPAL = result[i++].Value?.ToString();
            dta.IND_NULL_06 = string.IsNullOrWhiteSpace(dta.OD003_NUM_INSC_MUNICIPAL) ? "-1" : "0";
            dta.OD003_COD_UF = result[i++].Value?.ToString();
            dta.IND_NULL_07 = string.IsNullOrWhiteSpace(dta.OD003_COD_UF) ? "-1" : "0";
            dta.OD003_NUM_MUNICIPIO = result[i++].Value?.ToString();
            dta.IND_NULL_08 = string.IsNullOrWhiteSpace(dta.OD003_NUM_MUNICIPIO) ? "-1" : "0";
            dta.OD003_COD_CNAE = result[i++].Value?.ToString();
            dta.IND_NULL_09 = string.IsNullOrWhiteSpace(dta.OD003_COD_CNAE) ? "-1" : "0";
            dta.OD003_NUM_SOCIOS = result[i++].Value?.ToString();
            dta.IND_NULL_10 = string.IsNullOrWhiteSpace(dta.OD003_NUM_SOCIOS) ? "-1" : "0";
            dta.OD003_STA_FRANQUIA = result[i++].Value?.ToString();
            dta.IND_NULL_11 = string.IsNullOrWhiteSpace(dta.OD003_STA_FRANQUIA) ? "-1" : "0";
            dta.OD003_IND_FINALIDADE = result[i++].Value?.ToString();
            dta.IND_NULL_12 = string.IsNullOrWhiteSpace(dta.OD003_IND_FINALIDADE) ? "-1" : "0";

            return dta;
        }

    }
}