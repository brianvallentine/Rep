using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0913S
{
    public class EM0913S_CSR_MR023 : QueryBasis<EM0913S_CSR_MR023>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0913S_CSR_MR023() { IsCursor = true; }

        public EM0913S_CSR_MR023(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MR023_COD_FONTE { get; set; }
        public string MR023_NUM_PROPOSTA { get; set; }
        public string MR023_NUM_ITEM { get; set; }
        public string MR023_NUM_TP_CONDOMINIO { get; set; }
        public string MR023_NUM_PAVIMENTOS { get; set; }
        public string MR023_NUM_ELEVADORES { get; set; }
        public string MR023_NUM_PORTAO_ELETRON { get; set; }
        public string MR023_NUM_VAGAS { get; set; }
        public string MR023_NUM_UNID_AUTONOMA { get; set; }
        public string MR023_PCT_DESC_COBERTURA { get; set; }
        public string MR023_PCT_BONUS_RENOVCAO { get; set; }
        public string MR023_PCT_DESC_PROMOCAO { get; set; }
        public string MR023_PCT_DESC_CORRETOR { get; set; }
        public string MR023_COD_BENEFICIARIO { get; set; }
        public string WNULL_COD_COND { get; set; }
        public string MR023_DES_CLAUSULA_BENEF { get; set; }
        public string WNULL_DES_COND { get; set; }

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


        public override EM0913S_CSR_MR023 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0913S_CSR_MR023();
            var i = 0;

            dta.MR023_COD_FONTE = result[i++].Value?.ToString();
            dta.MR023_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MR023_NUM_ITEM = result[i++].Value?.ToString();
            dta.MR023_NUM_TP_CONDOMINIO = result[i++].Value?.ToString();
            dta.MR023_NUM_PAVIMENTOS = result[i++].Value?.ToString();
            dta.MR023_NUM_ELEVADORES = result[i++].Value?.ToString();
            dta.MR023_NUM_PORTAO_ELETRON = result[i++].Value?.ToString();
            dta.MR023_NUM_VAGAS = result[i++].Value?.ToString();
            dta.MR023_NUM_UNID_AUTONOMA = result[i++].Value?.ToString();
            dta.MR023_PCT_DESC_COBERTURA = result[i++].Value?.ToString();
            dta.MR023_PCT_BONUS_RENOVCAO = result[i++].Value?.ToString();
            dta.MR023_PCT_DESC_PROMOCAO = result[i++].Value?.ToString();
            dta.MR023_PCT_DESC_CORRETOR = result[i++].Value?.ToString();
            dta.MR023_COD_BENEFICIARIO = result[i++].Value?.ToString();
            dta.WNULL_COD_COND = string.IsNullOrWhiteSpace(dta.MR023_COD_BENEFICIARIO) ? "-1" : "0";
            dta.MR023_DES_CLAUSULA_BENEF = result[i++].Value?.ToString();
            dta.WNULL_DES_COND = string.IsNullOrWhiteSpace(dta.MR023_DES_CLAUSULA_BENEF) ? "-1" : "0";

            return dta;
        }

    }
}