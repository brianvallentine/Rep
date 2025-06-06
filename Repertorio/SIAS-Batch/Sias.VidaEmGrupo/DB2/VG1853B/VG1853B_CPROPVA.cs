using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class VG1853B_CPROPVA : QueryBasis<VG1853B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1853B_CPROPVA() { IsCursor = true; }

        public VG1853B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_DTQITBCO { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_NRPRIPARATZ { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0PROP_INRMATRFUN { get; set; }
        public string V0PROP_TIMESTAMP { get; set; }
        public string V0PROP_DTMINVEN { get; set; }
        public string V0PROP_DTQITBCO_1YEAR { get; set; }
        public string V0PROP_CODOPER { get; set; }
        public string V0PROP_DTADMISSAO { get; set; }
        public string V0PROP_OCORHIST { get; set; }

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


        public override VG1853B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1853B_CPROPVA();
            var i = 0;

            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.V0PROP_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PROP_DTPROXVEN = result[i++].Value?.ToString();
            dta.V0PROP_NRPRIPARATZ = result[i++].Value?.ToString();
            dta.V0PROP_QTDPARATZ = result[i++].Value?.ToString();
            dta.V0PROP_NRMATRFUN = result[i++].Value?.ToString();
            dta.V0PROP_INRMATRFUN = string.IsNullOrWhiteSpace(dta.V0PROP_NRMATRFUN) ? "-1" : "0";
            dta.V0PROP_TIMESTAMP = result[i++].Value?.ToString();
            dta.V0PROP_DTMINVEN = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO_1YEAR = result[i++].Value?.ToString();
            dta.V0PROP_CODOPER = result[i++].Value?.ToString();
            dta.V0PROP_DTADMISSAO = result[i++].Value?.ToString();
            dta.V0PROP_OCORHIST = result[i++].Value?.ToString();

            return dta;
        }

    }
}