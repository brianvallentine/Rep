using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class VA0010B_CSEGURAVG : QueryBasis<VA0010B_CSEGURAVG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0010B_CSEGURAVG() { IsCursor = true; }

        public VA0010B_CSEGURAVG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1SEGV_NUM_APOLICE { get; set; }
        public string V1SEGV_COD_SUBGRUPO { get; set; }
        public string V1SEGV_NRCERTIF { get; set; }
        public string V1SEGV_DVCERTIF { get; set; }
        public string V1SEGV_ITEM { get; set; }
        public string V1SEGV_CODCLI { get; set; }
        public string V1SEGV_FONTE { get; set; }
        public string V1SEGV_OCORHIST { get; set; }
        public string V1SEGV_EST_CIVIL { get; set; }
        public string V1SEGV_IDE_SEXO { get; set; }
        public string V1SEGV_OCORR_END { get; set; }
        public string V1SEGV_MATRICULA { get; set; }
        public string V1SEGV_DTINIVIG { get; set; }
        public string V1SEGV_DTADMISS { get; set; }
        public string V1SEGV_DTADMISS_I { get; set; }
        public string V1SEGV_DTNASCIM { get; set; }
        public string V1SEGV_DTNASCIM_I { get; set; }
        public string V1SEGV_SITUACAO { get; set; }
        public string V1SEGV_NRPROPOS { get; set; }
        public string V1SEGV_NUM_CARNE { get; set; }

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


        public override VA0010B_CSEGURAVG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0010B_CSEGURAVG();
            var i = 0;

            dta.V1SEGV_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V1SEGV_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.V1SEGV_NRCERTIF = result[i++].Value?.ToString();
            dta.V1SEGV_DVCERTIF = result[i++].Value?.ToString();
            dta.V1SEGV_ITEM = result[i++].Value?.ToString();
            dta.V1SEGV_CODCLI = result[i++].Value?.ToString();
            dta.V1SEGV_FONTE = result[i++].Value?.ToString();
            dta.V1SEGV_OCORHIST = result[i++].Value?.ToString();
            dta.V1SEGV_EST_CIVIL = result[i++].Value?.ToString();
            dta.V1SEGV_IDE_SEXO = result[i++].Value?.ToString();
            dta.V1SEGV_OCORR_END = result[i++].Value?.ToString();
            dta.V1SEGV_MATRICULA = result[i++].Value?.ToString();
            dta.V1SEGV_DTINIVIG = result[i++].Value?.ToString();
            dta.V1SEGV_DTADMISS = result[i++].Value?.ToString();
            dta.V1SEGV_DTADMISS_I = string.IsNullOrWhiteSpace(dta.V1SEGV_DTADMISS) ? "-1" : "0";
            dta.V1SEGV_DTNASCIM = result[i++].Value?.ToString();
            dta.V1SEGV_DTNASCIM_I = string.IsNullOrWhiteSpace(dta.V1SEGV_DTNASCIM) ? "-1" : "0";
            dta.V1SEGV_SITUACAO = result[i++].Value?.ToString();
            dta.V1SEGV_NRPROPOS = result[i++].Value?.ToString();
            dta.V1SEGV_NUM_CARNE = result[i++].Value?.ToString();

            return dta;
        }

    }
}