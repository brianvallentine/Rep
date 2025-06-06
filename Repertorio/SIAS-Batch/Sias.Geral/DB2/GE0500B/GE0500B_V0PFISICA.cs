using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0500B
{
    public class GE0500B_V0PFISICA : QueryBasis<GE0500B_V0PFISICA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0500B_V0PFISICA() { IsCursor = true; }

        public GE0500B_V0PFISICA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD002_NUM_PESSOA { get; set; }
        public string OD002_NUM_CPF { get; set; }
        public string OD002_NUM_DV_CPF { get; set; }
        public string OD002_NOM_PESSOA { get; set; }
        public string OD002_DTH_NASCIMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD002_STA_SEXO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string OD002_IND_ESTADO_CIVIL { get; set; }
        public string VIND_NULL03 { get; set; }
        public string OD002_STA_PESSOA { get; set; }
        public string OD002_NOM_TRATAMENTO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string OD002_COD_UF { get; set; }
        public string VIND_NULL05 { get; set; }
        public string OD002_NUM_MUNICIPIO { get; set; }
        public string VIND_NULL06 { get; set; }
        public string OD002_NUM_INSC_SOCIAL { get; set; }
        public string VIND_NULL07 { get; set; }
        public string OD002_NUM_DV_INSC_SOCIAL { get; set; }
        public string VIND_NULL08 { get; set; }
        public string OD002_NUM_GRAU_INSTRUCAO { get; set; }
        public string VIND_NULL09 { get; set; }
        public string OD002_NOM_REDUZIDO { get; set; }
        public string VIND_NULL10 { get; set; }
        public string OD002_COD_CBO { get; set; }
        public string VIND_NULL11 { get; set; }
        public string OD002_NOM_PRIMEIRO { get; set; }
        public string VIND_NULL12 { get; set; }
        public string OD002_NOM_ULTIMO { get; set; }
        public string VIND_NULL13 { get; set; }

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


        public override GE0500B_V0PFISICA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0500B_V0PFISICA();
            var i = 0;

            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD002_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD002_NUM_CPF = result[i++].Value?.ToString();
            dta.OD002_NUM_DV_CPF = result[i++].Value?.ToString();
            dta.OD002_NOM_PESSOA = result[i++].Value?.ToString();
            dta.OD002_DTH_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.OD002_DTH_NASCIMENTO) ? "-1" : "0";
            dta.OD002_STA_SEXO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.OD002_STA_SEXO) ? "-1" : "0";
            dta.OD002_IND_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.OD002_IND_ESTADO_CIVIL) ? "-1" : "0";
            dta.OD002_STA_PESSOA = result[i++].Value?.ToString();
            dta.OD002_NOM_TRATAMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.OD002_NOM_TRATAMENTO) ? "-1" : "0";
            dta.OD002_COD_UF = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.OD002_COD_UF) ? "-1" : "0";
            dta.OD002_NUM_MUNICIPIO = result[i++].Value?.ToString();
            dta.VIND_NULL06 = string.IsNullOrWhiteSpace(dta.OD002_NUM_MUNICIPIO) ? "-1" : "0";
            dta.OD002_NUM_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.VIND_NULL07 = string.IsNullOrWhiteSpace(dta.OD002_NUM_INSC_SOCIAL) ? "-1" : "0";
            dta.OD002_NUM_DV_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.VIND_NULL08 = string.IsNullOrWhiteSpace(dta.OD002_NUM_DV_INSC_SOCIAL) ? "-1" : "0";
            dta.OD002_NUM_GRAU_INSTRUCAO = result[i++].Value?.ToString();
            dta.VIND_NULL09 = string.IsNullOrWhiteSpace(dta.OD002_NUM_GRAU_INSTRUCAO) ? "-1" : "0";
            dta.OD002_NOM_REDUZIDO = result[i++].Value?.ToString();
            dta.VIND_NULL10 = string.IsNullOrWhiteSpace(dta.OD002_NOM_REDUZIDO) ? "-1" : "0";
            dta.OD002_COD_CBO = result[i++].Value?.ToString();
            dta.VIND_NULL11 = string.IsNullOrWhiteSpace(dta.OD002_COD_CBO) ? "-1" : "0";
            dta.OD002_NOM_PRIMEIRO = result[i++].Value?.ToString();
            dta.VIND_NULL12 = string.IsNullOrWhiteSpace(dta.OD002_NOM_PRIMEIRO) ? "-1" : "0";
            dta.OD002_NOM_ULTIMO = result[i++].Value?.ToString();
            dta.VIND_NULL13 = string.IsNullOrWhiteSpace(dta.OD002_NOM_ULTIMO) ? "-1" : "0";

            return dta;
        }

    }
}