using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class SI0021B_V1HISTSIN : QueryBasis<SI0021B_V1HISTSIN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0021B_V1HISTSIN() { IsCursor = true; }

        public SI0021B_V1HISTSIN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HIST_OPERACAO { get; set; }
        public string V1HIST_OCORHIST { get; set; }
        public string V1HIST_NOMFAV { get; set; }
        public string V1HIST_DTMOVTO { get; set; }
        public string V1HIST_VAL_OPER { get; set; }
        public string V1HIST_LIMCRR { get; set; }
        public string V1MEST_NUM_APOL { get; set; }
        public string V1MEST_NRENDOS { get; set; }
        public string V1MEST_APOL_SINI { get; set; }
        public string V1MEST_DATCMD { get; set; }
        public string V1MEST_DATORR { get; set; }
        public string V1MEST_NRCERTIF { get; set; }
        public string V1MEST_MOEDA_SINI { get; set; }
        public string V1MEST_IDTPSEGU { get; set; }
        public string V1MEST_NUMIRB { get; set; }
        public string V1MEST_CODSUBES { get; set; }
        public string V1MEST_NREMBARQ { get; set; }
        public string V1MEST_REFEMBQ { get; set; }
        public string V1MEST_VALSEGBT { get; set; }
        public string V1MEST_PCPARTIC { get; set; }
        public string V1MEST_CODCAU { get; set; }
        public string V1MEST_RAMO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string V1RELA_COD_USUARIO { get; set; }
        public string RELATORI_COD_CONGENERE { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string WS_TIPO_CURSOR { get; set; }

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


        public override SI0021B_V1HISTSIN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0021B_V1HISTSIN();
            var i = 0;

            dta.V1HIST_OPERACAO = result[i++].Value?.ToString();
            dta.V1HIST_OCORHIST = result[i++].Value?.ToString();
            dta.V1HIST_NOMFAV = result[i++].Value?.ToString();
            dta.V1HIST_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HIST_VAL_OPER = result[i++].Value?.ToString();
            dta.V1HIST_LIMCRR = result[i++].Value?.ToString();
            dta.V1MEST_NUM_APOL = result[i++].Value?.ToString();
            dta.V1MEST_NRENDOS = result[i++].Value?.ToString();
            dta.V1MEST_APOL_SINI = result[i++].Value?.ToString();
            dta.V1MEST_DATCMD = result[i++].Value?.ToString();
            dta.V1MEST_DATORR = result[i++].Value?.ToString();
            dta.V1MEST_NRCERTIF = result[i++].Value?.ToString();
            dta.V1MEST_MOEDA_SINI = result[i++].Value?.ToString();
            dta.V1MEST_IDTPSEGU = result[i++].Value?.ToString();
            dta.V1MEST_NUMIRB = result[i++].Value?.ToString();
            dta.V1MEST_CODSUBES = result[i++].Value?.ToString();
            dta.V1MEST_NREMBARQ = result[i++].Value?.ToString();
            dta.V1MEST_REFEMBQ = result[i++].Value?.ToString();
            dta.V1MEST_VALSEGBT = result[i++].Value?.ToString();
            dta.V1MEST_PCPARTIC = result[i++].Value?.ToString();
            dta.V1MEST_CODCAU = result[i++].Value?.ToString();
            dta.V1MEST_RAMO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.V1RELA_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_COD_CONGENERE = result[i++].Value?.ToString();
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            dta.WS_TIPO_CURSOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}