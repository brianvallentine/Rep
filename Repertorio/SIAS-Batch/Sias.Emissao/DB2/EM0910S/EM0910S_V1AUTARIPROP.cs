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
    public class EM0910S_V1AUTARIPROP : QueryBasis<EM0910S_V1AUTARIPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0910S_V1AUTARIPROP() { IsCursor = true; }

        public EM0910S_V1AUTARIPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1TAPR_COD_EMPRESA { get; set; }
        public string V1TAPR_FONTE { get; set; }
        public string V1TAPR_NRPROPOS { get; set; }
        public string V1TAPR_NRITEM { get; set; }
        public string V1TAPR_DTINIVIG { get; set; }
        public string V1TAPR_DTTERVIG { get; set; }
        public string V1TAPR_TERCEIXO { get; set; }
        public string V1TAPR_CATTARIF { get; set; }
        public string V1TAPR_TIPOCOB { get; set; }
        public string V1TAPR_REGIAO { get; set; }
        public string V1TAPR_FRANQFAC { get; set; }
        public string V1TAPR_CLABONAT { get; set; }
        public string V1TAPR_PCDESCAT { get; set; }
        public string V1TAPR_CLABONDM { get; set; }
        public string V1TAPR_CLABONDP { get; set; }
        public string V1TAPR_CATTARIR { get; set; }
        public string V1TAPR_DESCFROT { get; set; }
        public string V1TAPR_NUMPASSG { get; set; }
        public string V1TAPR_VRFROBR_IX { get; set; }
        public string V1TAPR_VRFRFACC_IX { get; set; }
        public string V1TAPR_VRFRFACA_IX { get; set; }
        public string V1TAPR_VRFRADIC_IX { get; set; }
        public string V1TAPR_VRPRREF { get; set; }
        public string V1TAPR_CFFROBR { get; set; }
        public string V1TAPR_CFFRFACC { get; set; }
        public string V1TAPR_CFFRFACA { get; set; }
        public string V1TAPR_CFPRREF { get; set; }
        public string V1TAPR_PCDSCFRF { get; set; }
        public string V1TAPR_PCISCASC { get; set; }
        public string V1TAPR_PCINCROU { get; set; }
        public string V1TAPR_PCAGPLCA { get; set; }
        public string V1TAPR_PCAGPLAC { get; set; }
        public string V1TAPR_VRPRRFDM { get; set; }
        public string V1TAPR_VRPRRFDP { get; set; }
        public string V1TAPR_EXTPER { get; set; }
        public string V1TAPR_PERIODO { get; set; }
        public string V1TAPR_PCFRADIC { get; set; }
        public string V1TAPR_PRAZOSEG { get; set; }
        public string V1TAPR_DESCIDAD { get; set; }
        public string V1TAPR_TCFAPLPR { get; set; }
        public string V1TAPR_TPCDSFRF { get; set; }
        public string V1TAPR_TPCDSBAU { get; set; }
        public string V1TAPR_TTXAPLIS { get; set; }
        public string V1TAPR_TPCPZSEG { get; set; }
        public string V1TAPR_TPRBRCDM { get; set; }
        public string V1TAPR_TCFPBRDM { get; set; }
        public string V1TAPR_TPRBRCDP { get; set; }
        public string V1TAPR_TCFPBRDP { get; set; }
        public string V1TAPR_TPCBONDM { get; set; }
        public string V1TAPR_TPCBONDP { get; set; }
        public string V1TAPR_TTXAPPM { get; set; }
        public string V1TAPR_TTXAPPI { get; set; }
        public string V1TAPR_TTXAPPA { get; set; }
        public string V1TAPR_TTXAPPD { get; set; }
        public string V1TAPR_TPCDSAPP { get; set; }
        public string V1TAPR_DATEND { get; set; }
        public string V1TAPR_TPCMAJOR { get; set; }
        public string V1TAPR_PCDESAUT { get; set; }
        public string V1TAPR_PCDESRCF { get; set; }
        public string V1TAPR_PCDESAPP { get; set; }
        public string V1TAPR_PCDESPLCA { get; set; }
        public string V1TAPR_PCDESPLRF { get; set; }
        public string V1TAPR_PCDESPLAP { get; set; }
        public string V1TAPR_PCAGPLRF { get; set; }
        public string V1TAPR_PCAGPLAP { get; set; }
        public string V1TAPR_PCDESACE { get; set; }
        public string V1TAPR_PCAGISCASC { get; set; }
        public string VIND_PCAGISCASC { get; set; }
        public string V1TAPR_VALOR_AVARIA { get; set; }
        public string V1TAPR_TPCBONDMO { get; set; }
        public string V1TAPR_TCFPBRDMO { get; set; }
        public string V1TAPR_IND_COML { get; set; }
        public string V1TAPR_PCT_COML { get; set; }
        public string V1TAPR_CODUSU { get; set; }
        public string V1TAPR_IND_VLR_MIN { get; set; }

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


        public override EM0910S_V1AUTARIPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0910S_V1AUTARIPROP();
            var i = 0;

            dta.V1TAPR_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1TAPR_FONTE = result[i++].Value?.ToString();
            dta.V1TAPR_NRPROPOS = result[i++].Value?.ToString();
            dta.V1TAPR_NRITEM = result[i++].Value?.ToString();
            dta.V1TAPR_DTINIVIG = result[i++].Value?.ToString();
            dta.V1TAPR_DTTERVIG = result[i++].Value?.ToString();
            dta.V1TAPR_TERCEIXO = result[i++].Value?.ToString();
            dta.V1TAPR_CATTARIF = result[i++].Value?.ToString();
            dta.V1TAPR_TIPOCOB = result[i++].Value?.ToString();
            dta.V1TAPR_REGIAO = result[i++].Value?.ToString();
            dta.V1TAPR_FRANQFAC = result[i++].Value?.ToString();
            dta.V1TAPR_CLABONAT = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESCAT = result[i++].Value?.ToString();
            dta.V1TAPR_CLABONDM = result[i++].Value?.ToString();
            dta.V1TAPR_CLABONDP = result[i++].Value?.ToString();
            dta.V1TAPR_CATTARIR = result[i++].Value?.ToString();
            dta.V1TAPR_DESCFROT = result[i++].Value?.ToString();
            dta.V1TAPR_NUMPASSG = result[i++].Value?.ToString();
            dta.V1TAPR_VRFROBR_IX = result[i++].Value?.ToString();
            dta.V1TAPR_VRFRFACC_IX = result[i++].Value?.ToString();
            dta.V1TAPR_VRFRFACA_IX = result[i++].Value?.ToString();
            dta.V1TAPR_VRFRADIC_IX = result[i++].Value?.ToString();
            dta.V1TAPR_VRPRREF = result[i++].Value?.ToString();
            dta.V1TAPR_CFFROBR = result[i++].Value?.ToString();
            dta.V1TAPR_CFFRFACC = result[i++].Value?.ToString();
            dta.V1TAPR_CFFRFACA = result[i++].Value?.ToString();
            dta.V1TAPR_CFPRREF = result[i++].Value?.ToString();
            dta.V1TAPR_PCDSCFRF = result[i++].Value?.ToString();
            dta.V1TAPR_PCISCASC = result[i++].Value?.ToString();
            dta.V1TAPR_PCINCROU = result[i++].Value?.ToString();
            dta.V1TAPR_PCAGPLCA = result[i++].Value?.ToString();
            dta.V1TAPR_PCAGPLAC = result[i++].Value?.ToString();
            dta.V1TAPR_VRPRRFDM = result[i++].Value?.ToString();
            dta.V1TAPR_VRPRRFDP = result[i++].Value?.ToString();
            dta.V1TAPR_EXTPER = result[i++].Value?.ToString();
            dta.V1TAPR_PERIODO = result[i++].Value?.ToString();
            dta.V1TAPR_PCFRADIC = result[i++].Value?.ToString();
            dta.V1TAPR_PRAZOSEG = result[i++].Value?.ToString();
            dta.V1TAPR_DESCIDAD = result[i++].Value?.ToString();
            dta.V1TAPR_TCFAPLPR = result[i++].Value?.ToString();
            dta.V1TAPR_TPCDSFRF = result[i++].Value?.ToString();
            dta.V1TAPR_TPCDSBAU = result[i++].Value?.ToString();
            dta.V1TAPR_TTXAPLIS = result[i++].Value?.ToString();
            dta.V1TAPR_TPCPZSEG = result[i++].Value?.ToString();
            dta.V1TAPR_TPRBRCDM = result[i++].Value?.ToString();
            dta.V1TAPR_TCFPBRDM = result[i++].Value?.ToString();
            dta.V1TAPR_TPRBRCDP = result[i++].Value?.ToString();
            dta.V1TAPR_TCFPBRDP = result[i++].Value?.ToString();
            dta.V1TAPR_TPCBONDM = result[i++].Value?.ToString();
            dta.V1TAPR_TPCBONDP = result[i++].Value?.ToString();
            dta.V1TAPR_TTXAPPM = result[i++].Value?.ToString();
            dta.V1TAPR_TTXAPPI = result[i++].Value?.ToString();
            dta.V1TAPR_TTXAPPA = result[i++].Value?.ToString();
            dta.V1TAPR_TTXAPPD = result[i++].Value?.ToString();
            dta.V1TAPR_TPCDSAPP = result[i++].Value?.ToString();
            dta.V1TAPR_DATEND = result[i++].Value?.ToString();
            dta.V1TAPR_TPCMAJOR = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESAUT = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESRCF = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESAPP = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESPLCA = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESPLRF = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESPLAP = result[i++].Value?.ToString();
            dta.V1TAPR_PCAGPLRF = result[i++].Value?.ToString();
            dta.V1TAPR_PCAGPLAP = result[i++].Value?.ToString();
            dta.V1TAPR_PCDESACE = result[i++].Value?.ToString();
            dta.V1TAPR_PCAGISCASC = result[i++].Value?.ToString();
            dta.VIND_PCAGISCASC = string.IsNullOrWhiteSpace(dta.V1TAPR_PCAGISCASC) ? "-1" : "0";
            dta.V1TAPR_VALOR_AVARIA = result[i++].Value?.ToString();
            dta.V1TAPR_TPCBONDMO = result[i++].Value?.ToString();
            dta.V1TAPR_TCFPBRDMO = result[i++].Value?.ToString();
            dta.V1TAPR_IND_COML = result[i++].Value?.ToString();
            dta.V1TAPR_PCT_COML = result[i++].Value?.ToString();
            dta.V1TAPR_CODUSU = result[i++].Value?.ToString();
            dta.V1TAPR_IND_VLR_MIN = result[i++].Value?.ToString();

            return dta;
        }

    }
}