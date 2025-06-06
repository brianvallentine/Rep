using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class EM0910S_V1AUTOPROP : QueryBasis<EM0910S_V1AUTOPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0910S_V1AUTOPROP() { IsCursor = true; }

        public EM0910S_V1AUTOPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1AUPR_COD_EMPRESA { get; set; }
        public string V1AUPR_FONTE { get; set; }
        public string V1AUPR_NRPROPOS { get; set; }
        public string V1AUPR_NRITEM { get; set; }
        public string V1AUPR_DTINIVIG { get; set; }
        public string V1AUPR_DTTERVIG { get; set; }
        public string V1AUPR_TIPOVEIC { get; set; }
        public string V1AUPR_FABRICAN { get; set; }
        public string V1AUPR_CDVEICL { get; set; }
        public string V1AUPR_COMBUST { get; set; }
        public string V1AUPR_ANOVEICL { get; set; }
        public string V1AUPR_ANOMOD { get; set; }
        public string V1AUPR_CORVEICL { get; set; }
        public string V1AUPR_CAPACID { get; set; }
        public string V1AUPR_LOTACAO { get; set; }
        public string V1AUPR_PLACAUF { get; set; }
        public string V1AUPR_PLACALET { get; set; }
        public string V1AUPR_PLACANR { get; set; }
        public string V1AUPR_CHASSIS { get; set; }
        public string V1AUPR_UTILIZA { get; set; }
        public string V1AUPR_QTACESS { get; set; }
        public string V1AUPR_DTBAIXA { get; set; }
        public string V1AUPR_CDVISTOR { get; set; }
        public string V1AUPR_PROPRIET { get; set; }
        public string V1AUPR_DTIVEXTP { get; set; }
        public string V1AUPR_ACEITE { get; set; }
        public string V1AUPR_NRPRRESS { get; set; }
        public string V1AUPR_PROTSINI { get; set; }
        public string V1AUPR_SITUACAO { get; set; }
        public string V1AUPR_CODCLIEN { get; set; }
        public string V1AUPR_TPMOVTO { get; set; }
        public string V1AUPR_ZEROKM { get; set; }
        public string V1INDI_ZEROKM { get; set; }
        public string V1AUPR_SEGBONUS { get; set; }
        public string V1INDI_SEGBONUS { get; set; }
        public string V1AUPR_FIDEL_AUTO { get; set; }
        public string V1AUPR_FIDEL_VIDA { get; set; }
        public string V1AUPR_FIDEL_PREV { get; set; }
        public string V1AUPR_DANOS_MORAIS { get; set; }
        public string V1AUPR_SEG_MERC_DET { get; set; }
        public string V1AUPR_ADIC_VLR_MERCADO { get; set; }
        public string V1AUPR_PERFIL { get; set; }
        public string V1AUPR_DESPEXTR { get; set; }
        public string V1AUPR_VLNOVO { get; set; }
        public string V1AUPR_CODDESPEXTR { get; set; }
        public string V1AUPR_DESPEXTR_PT { get; set; }
        public string V1AUPR_VARIA_IS { get; set; }
        public string V1AUPR_CANAL_PROPOSTA { get; set; }
        public string V1AUPR_TIPO_COBRANCA { get; set; }
        public string V1AUPR_NUM_PROP_CNV { get; set; }
        public string V1AUPR_NUM_CERTIF { get; set; }
        public string V1AUPR_NUM_RENAVAM { get; set; }
        public string V1AUPR_IND_USO_VEIC { get; set; }

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


        public override EM0910S_V1AUTOPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0910S_V1AUTOPROP();
            var i = 0;

            dta.V1AUPR_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1AUPR_FONTE = result[i++].Value?.ToString();
            dta.V1AUPR_NRPROPOS = result[i++].Value?.ToString();
            dta.V1AUPR_NRITEM = result[i++].Value?.ToString();
            dta.V1AUPR_DTINIVIG = result[i++].Value?.ToString();
            dta.V1AUPR_DTTERVIG = result[i++].Value?.ToString();
            dta.V1AUPR_TIPOVEIC = result[i++].Value?.ToString();
            dta.V1AUPR_FABRICAN = result[i++].Value?.ToString();
            dta.V1AUPR_CDVEICL = result[i++].Value?.ToString();
            dta.V1AUPR_COMBUST = result[i++].Value?.ToString();
            dta.V1AUPR_ANOVEICL = result[i++].Value?.ToString();
            dta.V1AUPR_ANOMOD = result[i++].Value?.ToString();
            dta.V1AUPR_CORVEICL = result[i++].Value?.ToString();
            dta.V1AUPR_CAPACID = result[i++].Value?.ToString();
            dta.V1AUPR_LOTACAO = result[i++].Value?.ToString();
            dta.V1AUPR_PLACAUF = result[i++].Value?.ToString();
            dta.V1AUPR_PLACALET = result[i++].Value?.ToString();
            dta.V1AUPR_PLACANR = result[i++].Value?.ToString();
            dta.V1AUPR_CHASSIS = result[i++].Value?.ToString();
            dta.V1AUPR_UTILIZA = result[i++].Value?.ToString();
            dta.V1AUPR_QTACESS = result[i++].Value?.ToString();
            dta.V1AUPR_DTBAIXA = result[i++].Value?.ToString();
            dta.V1AUPR_CDVISTOR = result[i++].Value?.ToString();
            dta.V1AUPR_PROPRIET = result[i++].Value?.ToString();
            dta.V1AUPR_DTIVEXTP = result[i++].Value?.ToString();
            dta.V1AUPR_ACEITE = result[i++].Value?.ToString();
            dta.V1AUPR_NRPRRESS = result[i++].Value?.ToString();
            dta.V1AUPR_PROTSINI = result[i++].Value?.ToString();
            dta.V1AUPR_SITUACAO = result[i++].Value?.ToString();
            dta.V1AUPR_CODCLIEN = result[i++].Value?.ToString();
            dta.V1AUPR_TPMOVTO = result[i++].Value?.ToString();
            dta.V1AUPR_ZEROKM = result[i++].Value?.ToString();
            dta.V1INDI_ZEROKM = string.IsNullOrWhiteSpace(dta.V1AUPR_ZEROKM) ? "-1" : "0";
            dta.V1AUPR_SEGBONUS = result[i++].Value?.ToString();
            dta.V1INDI_SEGBONUS = string.IsNullOrWhiteSpace(dta.V1AUPR_SEGBONUS) ? "-1" : "0";
            dta.V1AUPR_FIDEL_AUTO = result[i++].Value?.ToString();
            dta.V1AUPR_FIDEL_VIDA = result[i++].Value?.ToString();
            dta.V1AUPR_FIDEL_PREV = result[i++].Value?.ToString();
            dta.V1AUPR_DANOS_MORAIS = result[i++].Value?.ToString();
            dta.V1AUPR_SEG_MERC_DET = result[i++].Value?.ToString();
            dta.V1AUPR_ADIC_VLR_MERCADO = result[i++].Value?.ToString();
            dta.V1AUPR_PERFIL = result[i++].Value?.ToString();
            dta.V1AUPR_DESPEXTR = result[i++].Value?.ToString();
            dta.V1AUPR_VLNOVO = result[i++].Value?.ToString();
            dta.V1AUPR_CODDESPEXTR = result[i++].Value?.ToString();
            dta.V1AUPR_DESPEXTR_PT = result[i++].Value?.ToString();
            dta.V1AUPR_VARIA_IS = result[i++].Value?.ToString();
            dta.V1AUPR_CANAL_PROPOSTA = result[i++].Value?.ToString();
            dta.V1AUPR_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.V1AUPR_NUM_PROP_CNV = result[i++].Value?.ToString();
            dta.V1AUPR_NUM_CERTIF = result[i++].Value?.ToString();
            dta.V1AUPR_NUM_RENAVAM = result[i++].Value?.ToString();
            dta.V1AUPR_IND_USO_VEIC = result[i++].Value?.ToString();

            return dta;
        }

    }
}