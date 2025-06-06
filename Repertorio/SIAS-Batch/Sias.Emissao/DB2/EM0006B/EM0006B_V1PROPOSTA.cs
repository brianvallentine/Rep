using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class EM0006B_V1PROPOSTA : QueryBasis<EM0006B_V1PROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPOSTA() { IsCursor = true; }

        public EM0006B_V1PROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PROP_TPPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_RAMO { get; set; }
        public string V1PROP_MODALIDA { get; set; }
        public string V1PROP_NUM_APO_ANT { get; set; }
        public string V1PROP_TIPAPO { get; set; }
        public string V1PROP_CODCLIEN { get; set; }
        public string V1PROP_DTINIVIG { get; set; }
        public string V1PROP_DTTERVIG { get; set; }
        public string V1PROP_PODPUBL { get; set; }
        public string V1PROP_CORRECAO { get; set; }
        public string V1PROP_MOEDA_IMP { get; set; }
        public string V1PROP_MOEDA_PRM { get; set; }
        public string V1PROP_PRESTA1 { get; set; }
        public string V1PROP_BCORCAP { get; set; }
        public string V1PROP_AGERCAP { get; set; }
        public string V1PROP_NRRCAP { get; set; }
        public string V1PROP_VLRCAP { get; set; }
        public string V1PROP_CDFRACIO { get; set; }
        public string V1PROP_QTPARCEL { get; set; }
        public string V1PROP_PCENTRAD { get; set; }
        public string V1PROP_PCADICIO { get; set; }
        public string V1PROP_IDIOF { get; set; }
        public string V1PROP_ISENTA_CST { get; set; }
        public string V1PROP_QTPRESTA { get; set; }
        public string V1PROP_BCOCOBR { get; set; }
        public string V1PROP_AGECOBR { get; set; }
        public string V1PROP_TPCORRET { get; set; }
        public string V1PROP_NRAUTCOR { get; set; }
        public string V1PROP_QTCORR { get; set; }
        public string V1PROP_QTCORRC { get; set; }
        public string V1PROP_NUM_APO_MAN { get; set; }
        public string V1PROP_TPCOSCED { get; set; }
        public string V1PROP_QTCOSSGC { get; set; }
        public string V1PROP_QTCOSSEG { get; set; }
        public string V1PROP_QTITENSI { get; set; }
        public string V1PROP_QTITENS { get; set; }
        public string V1PROP_TPMOVTO { get; set; }
        public string V1PROP_DTENTRAD { get; set; }
        public string V1PROP_DTCADAST { get; set; }
        public string V1PROP_TIPCALC { get; set; }
        public string V1PROP_LIMIND { get; set; }
        public string V1PROP_CDACEITA { get; set; }
        public string V1PROP_NRAUTACE { get; set; }
        public string V1PROP_PCDESCON { get; set; }
        public string V1PROP_IDRCAP { get; set; }
        public string V1PROP_CODTXT { get; set; }
        public string V1PROP_NUM_RENOV { get; set; }
        public string V1PROP_CONV_COBR { get; set; }
        public string V1PROP_OCORR_END { get; set; }
        public string V1PROP_SITUACAO { get; set; }
        public string V1PROP_COD_USUAR { get; set; }
        public string V1PROP_NUM_ATA { get; set; }
        public string VIND_NUM_ATA { get; set; }
        public string V1PROP_ANO_ATA { get; set; }
        public string VIND_ANO_ATA { get; set; }
        public string V1PROP_DATA_SORT { get; set; }
        public string VIND_DAT_SORT { get; set; }
        public string V1PROP_DTLIBER { get; set; }
        public string VIND_DTLIBER { get; set; }
        public string V1PROP_DTAPOLM { get; set; }
        public string VIND_DTAPOLM { get; set; }
        public string V1PROP_DATARCAP { get; set; }
        public string VIND_DAT_RCAP { get; set; }
        public string V1PROP_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V1PROP_TIMESTAMP { get; set; }
        public string VIND_TIMESTAMP { get; set; }
        public string V1PROP_TIPO_ENDO { get; set; }
        public string VIND_TIPO_ENDOSSO { get; set; }
        public string V1PROP_NUM_APOLICE { get; set; }
        public string VIND_NUM_APOLICE { get; set; }
        public string V1PROP_INSPETOR { get; set; }
        public string VIND_INSPETOR { get; set; }
        public string V1PROP_CANALPROD { get; set; }
        public string VIND_CANALPROD { get; set; }
        public string V1PROP_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V1PROP_DTVENCTO { get; set; }
        public string VIND_DTVENCTO { get; set; }
        public string V1PROP_CFPREFIX { get; set; }
        public string VIND_CFPREFIX { get; set; }
        public string V1PROP_VLCUSEMI { get; set; }
        public string VIND_VLCUSEMI { get; set; }

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


        public override EM0006B_V1PROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPOSTA();
            var i = 0;

            dta.V1PROP_TPPROPOS = result[i++].Value?.ToString();
            dta.V1PROP_FONTE = result[i++].Value?.ToString();
            dta.V1PROP_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PROP_RAMO = result[i++].Value?.ToString();
            dta.V1PROP_MODALIDA = result[i++].Value?.ToString();
            dta.V1PROP_NUM_APO_ANT = result[i++].Value?.ToString();
            dta.V1PROP_TIPAPO = result[i++].Value?.ToString();
            dta.V1PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V1PROP_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PROP_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PROP_PODPUBL = result[i++].Value?.ToString();
            dta.V1PROP_CORRECAO = result[i++].Value?.ToString();
            dta.V1PROP_MOEDA_IMP = result[i++].Value?.ToString();
            dta.V1PROP_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V1PROP_PRESTA1 = result[i++].Value?.ToString();
            dta.V1PROP_BCORCAP = result[i++].Value?.ToString();
            dta.V1PROP_AGERCAP = result[i++].Value?.ToString();
            dta.V1PROP_NRRCAP = result[i++].Value?.ToString();
            dta.V1PROP_VLRCAP = result[i++].Value?.ToString();
            dta.V1PROP_CDFRACIO = result[i++].Value?.ToString();
            dta.V1PROP_QTPARCEL = result[i++].Value?.ToString();
            dta.V1PROP_PCENTRAD = result[i++].Value?.ToString();
            dta.V1PROP_PCADICIO = result[i++].Value?.ToString();
            dta.V1PROP_IDIOF = result[i++].Value?.ToString();
            dta.V1PROP_ISENTA_CST = result[i++].Value?.ToString();
            dta.V1PROP_QTPRESTA = result[i++].Value?.ToString();
            dta.V1PROP_BCOCOBR = result[i++].Value?.ToString();
            dta.V1PROP_AGECOBR = result[i++].Value?.ToString();
            dta.V1PROP_TPCORRET = result[i++].Value?.ToString();
            dta.V1PROP_NRAUTCOR = result[i++].Value?.ToString();
            dta.V1PROP_QTCORR = result[i++].Value?.ToString();
            dta.V1PROP_QTCORRC = result[i++].Value?.ToString();
            dta.V1PROP_NUM_APO_MAN = result[i++].Value?.ToString();
            dta.V1PROP_TPCOSCED = result[i++].Value?.ToString();
            dta.V1PROP_QTCOSSGC = result[i++].Value?.ToString();
            dta.V1PROP_QTCOSSEG = result[i++].Value?.ToString();
            dta.V1PROP_QTITENSI = result[i++].Value?.ToString();
            dta.V1PROP_QTITENS = result[i++].Value?.ToString();
            dta.V1PROP_TPMOVTO = result[i++].Value?.ToString();
            dta.V1PROP_DTENTRAD = result[i++].Value?.ToString();
            dta.V1PROP_DTCADAST = result[i++].Value?.ToString();
            dta.V1PROP_TIPCALC = result[i++].Value?.ToString();
            dta.V1PROP_LIMIND = result[i++].Value?.ToString();
            dta.V1PROP_CDACEITA = result[i++].Value?.ToString();
            dta.V1PROP_NRAUTACE = result[i++].Value?.ToString();
            dta.V1PROP_PCDESCON = result[i++].Value?.ToString();
            dta.V1PROP_IDRCAP = result[i++].Value?.ToString();
            dta.V1PROP_CODTXT = result[i++].Value?.ToString();
            dta.V1PROP_NUM_RENOV = result[i++].Value?.ToString();
            dta.V1PROP_CONV_COBR = result[i++].Value?.ToString();
            dta.V1PROP_OCORR_END = result[i++].Value?.ToString();
            dta.V1PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V1PROP_COD_USUAR = result[i++].Value?.ToString();
            dta.V1PROP_NUM_ATA = result[i++].Value?.ToString();
            dta.VIND_NUM_ATA = string.IsNullOrWhiteSpace(dta.V1PROP_NUM_ATA) ? "-1" : "0";
            dta.V1PROP_ANO_ATA = result[i++].Value?.ToString();
            dta.VIND_ANO_ATA = string.IsNullOrWhiteSpace(dta.V1PROP_ANO_ATA) ? "-1" : "0";
            dta.V1PROP_DATA_SORT = result[i++].Value?.ToString();
            dta.VIND_DAT_SORT = string.IsNullOrWhiteSpace(dta.V1PROP_DATA_SORT) ? "-1" : "0";
            dta.V1PROP_DTLIBER = result[i++].Value?.ToString();
            dta.VIND_DTLIBER = string.IsNullOrWhiteSpace(dta.V1PROP_DTLIBER) ? "-1" : "0";
            dta.V1PROP_DTAPOLM = result[i++].Value?.ToString();
            dta.VIND_DTAPOLM = string.IsNullOrWhiteSpace(dta.V1PROP_DTAPOLM) ? "-1" : "0";
            dta.V1PROP_DATARCAP = result[i++].Value?.ToString();
            dta.VIND_DAT_RCAP = string.IsNullOrWhiteSpace(dta.V1PROP_DATARCAP) ? "-1" : "0";
            dta.V1PROP_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V1PROP_COD_EMPRESA) ? "-1" : "0";
            dta.V1PROP_TIMESTAMP = result[i++].Value?.ToString();
            dta.VIND_TIMESTAMP = string.IsNullOrWhiteSpace(dta.V1PROP_TIMESTAMP) ? "-1" : "0";
            dta.V1PROP_TIPO_ENDO = result[i++].Value?.ToString();
            dta.VIND_TIPO_ENDOSSO = string.IsNullOrWhiteSpace(dta.V1PROP_TIPO_ENDO) ? "-1" : "0";
            dta.V1PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VIND_NUM_APOLICE = string.IsNullOrWhiteSpace(dta.V1PROP_NUM_APOLICE) ? "-1" : "0";
            dta.V1PROP_INSPETOR = result[i++].Value?.ToString();
            dta.VIND_INSPETOR = string.IsNullOrWhiteSpace(dta.V1PROP_INSPETOR) ? "-1" : "0";
            dta.V1PROP_CANALPROD = result[i++].Value?.ToString();
            dta.VIND_CANALPROD = string.IsNullOrWhiteSpace(dta.V1PROP_CANALPROD) ? "-1" : "0";
            dta.V1PROP_CODPRODU = result[i++].Value?.ToString();
            dta.VIND_CODPRODU = string.IsNullOrWhiteSpace(dta.V1PROP_CODPRODU) ? "-1" : "0";
            dta.V1PROP_DTVENCTO = result[i++].Value?.ToString();
            dta.VIND_DTVENCTO = string.IsNullOrWhiteSpace(dta.V1PROP_DTVENCTO) ? "-1" : "0";
            dta.V1PROP_CFPREFIX = result[i++].Value?.ToString();
            dta.VIND_CFPREFIX = string.IsNullOrWhiteSpace(dta.V1PROP_CFPREFIX) ? "-1" : "0";
            dta.V1PROP_VLCUSEMI = result[i++].Value?.ToString();
            dta.VIND_VLCUSEMI = string.IsNullOrWhiteSpace(dta.V1PROP_VLCUSEMI) ? "-1" : "0";

            return dta;
        }

    }
}