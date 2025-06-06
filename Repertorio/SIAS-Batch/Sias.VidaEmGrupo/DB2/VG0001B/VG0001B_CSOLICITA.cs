using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class VG0001B_CSOLICITA : QueryBasis<VG0001B_CSOLICITA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0001B_CSOLICITA() { IsCursor = true; }

        public VG0001B_CSOLICITA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_DATA_SOLICITACAO { get; set; }
        public string VGSOLFAT_DIA_DEBITO { get; set; }
        public string VGSOLFAT_OPCAOPAG { get; set; }
        public string VGSOLFAT_QUANT_VIDAS { get; set; }
        public string VGSOLFAT_CAP_BAS_SEGURADO { get; set; }
        public string VGSOLFAT_PRM_VG { get; set; }
        public string VGSOLFAT_PRM_AP { get; set; }
        public string VGSOLFAT_PRM_TOTAL { get; set; }
        public string VGSOLFAT_DTVENCTO_FATURA { get; set; }
        public string VGSOLFAT_COD_FONTE { get; set; }
        public string VGSOLFAT_NUM_TITULO { get; set; }
        public string VGSOLFAT_DT_QUITBCO_TITULO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string VGSOLFAT_VALOR_TITULO { get; set; }
        public string VGSOLFAT_AGECTADEB { get; set; }
        public string VIND_AGECTADEB { get; set; }
        public string VGSOLFAT_OPRCTADEB { get; set; }
        public string VIND_OPRCTADEB { get; set; }
        public string VGSOLFAT_NUMCTADEB { get; set; }
        public string VIND_NUMCTADEB { get; set; }
        public string VGSOLFAT_DIGCTADEB { get; set; }
        public string VIND_DIGCTADEB { get; set; }
        public string VGSOLFAT_COD_USUARIO { get; set; }

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


        public override VG0001B_CSOLICITA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0001B_CSOLICITA();
            var i = 0;

            dta.VGSOLFAT_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VGSOLFAT_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.VGSOLFAT_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.VGSOLFAT_DIA_DEBITO = result[i++].Value?.ToString();
            dta.VGSOLFAT_OPCAOPAG = result[i++].Value?.ToString();
            dta.VGSOLFAT_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.VGSOLFAT_CAP_BAS_SEGURADO = result[i++].Value?.ToString();
            dta.VGSOLFAT_PRM_VG = result[i++].Value?.ToString();
            dta.VGSOLFAT_PRM_AP = result[i++].Value?.ToString();
            dta.VGSOLFAT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.VGSOLFAT_DTVENCTO_FATURA = result[i++].Value?.ToString();
            dta.VGSOLFAT_COD_FONTE = result[i++].Value?.ToString();
            dta.VGSOLFAT_NUM_TITULO = result[i++].Value?.ToString();
            dta.VGSOLFAT_DT_QUITBCO_TITULO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.VGSOLFAT_DT_QUITBCO_TITULO) ? "-1" : "0";
            dta.VGSOLFAT_VALOR_TITULO = result[i++].Value?.ToString();
            dta.VGSOLFAT_AGECTADEB = result[i++].Value?.ToString();
            dta.VIND_AGECTADEB = string.IsNullOrWhiteSpace(dta.VGSOLFAT_AGECTADEB) ? "-1" : "0";
            dta.VGSOLFAT_OPRCTADEB = result[i++].Value?.ToString();
            dta.VIND_OPRCTADEB = string.IsNullOrWhiteSpace(dta.VGSOLFAT_OPRCTADEB) ? "-1" : "0";
            dta.VGSOLFAT_NUMCTADEB = result[i++].Value?.ToString();
            dta.VIND_NUMCTADEB = string.IsNullOrWhiteSpace(dta.VGSOLFAT_NUMCTADEB) ? "-1" : "0";
            dta.VGSOLFAT_DIGCTADEB = result[i++].Value?.ToString();
            dta.VIND_DIGCTADEB = string.IsNullOrWhiteSpace(dta.VGSOLFAT_DIGCTADEB) ? "-1" : "0";
            dta.VGSOLFAT_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}