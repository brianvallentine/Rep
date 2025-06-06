using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class VA0853B_CPROPVAL : QueryBasis<VA0853B_CPROPVAL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0853B_CPROPVAL() { IsCursor = true; }

        public VA0853B_CPROPVAL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_TIPO_PROCESSAMENTO { get; set; }
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
        public string V0PROP_TIMESTAMP { get; set; }
        public string V0PROP_DTMINVEN { get; set; }
        public string V0PROP_DTQITBCO_1YEAR { get; set; }
        public string V0PROP_CODOPER { get; set; }
        public string V0PROP_DTADMISSAO { get; set; }
        public string V0PRDVG_ESTR_COBR { get; set; }
        public string V0PRDVG_ORIG_PRODU { get; set; }
        public string V0PRDVG_TEM_SAF { get; set; }
        public string V0PRDVG_TEM_CDG { get; set; }
        public string V0PRDVG_TEM_IGPM { get; set; }
        public string V0PRDVG_CODPRODAZ { get; set; }
        public string V0PRDVG_OPCAOCAP { get; set; }
        public string V0PRDVG_COBERADIC_PREMIO { get; set; }
        public string V0PRDVG_CUSTOCAP_TOTAL { get; set; }
        public string V0PRDVG_OPCAOPAG { get; set; }
        public string V0PRDVG_PERIPGTO { get; set; }
        public string V0PRDVG_NOMPRODU { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_DIA_DEBITO { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0OPCP_CARTAO_CRED { get; set; }
        public string VIND_CCRE { get; set; }

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


        public override VA0853B_CPROPVAL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0853B_CPROPVAL();
            var i = 0;

            dta.WS_TIPO_PROCESSAMENTO = result[i++].Value?.ToString();
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
            dta.V0PROP_TIMESTAMP = result[i++].Value?.ToString();
            dta.V0PROP_DTMINVEN = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO_1YEAR = result[i++].Value?.ToString();
            dta.V0PROP_CODOPER = result[i++].Value?.ToString();
            dta.V0PROP_DTADMISSAO = result[i++].Value?.ToString();
            dta.V0PRDVG_ESTR_COBR = result[i++].Value?.ToString();
            dta.V0PRDVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.V0PRDVG_TEM_SAF = result[i++].Value?.ToString();
            dta.V0PRDVG_TEM_CDG = result[i++].Value?.ToString();
            dta.V0PRDVG_TEM_IGPM = result[i++].Value?.ToString();
            dta.V0PRDVG_CODPRODAZ = result[i++].Value?.ToString();
            dta.V0PRDVG_OPCAOCAP = result[i++].Value?.ToString();
            dta.V0PRDVG_COBERADIC_PREMIO = result[i++].Value?.ToString();
            dta.V0PRDVG_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            dta.V0PRDVG_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0PRDVG_PERIPGTO = result[i++].Value?.ToString();
            dta.V0PRDVG_NOMPRODU = result[i++].Value?.ToString();
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_DIA_DEBITO = result[i++].Value?.ToString();
            dta.V0OPCP_AGECTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_OPRCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_NUMCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_DIGCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_CARTAO_CRED = result[i++].Value?.ToString();
            dta.VIND_CCRE = string.IsNullOrWhiteSpace(dta.V0OPCP_CARTAO_CRED) ? "-1" : "0";

            return dta;
        }

    }
}