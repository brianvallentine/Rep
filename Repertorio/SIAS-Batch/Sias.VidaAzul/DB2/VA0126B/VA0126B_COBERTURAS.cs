using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class VA0126B_COBERTURAS : QueryBasis<VA0126B_COBERTURAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0126B_COBERTURAS() { IsCursor = true; }

        public VA0126B_COBERTURAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCOBPR_NUM_CERTIFICADO { get; set; }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_DATA_TERVIGENCIA { get; set; }
        public string HISCOBPR_IMPSEGUR { get; set; }
        public string HISCOBPR_QUANT_VIDAS { get; set; }
        public string HISCOBPR_IMPSEGIND { get; set; }
        public string HISCOBPR_COD_OPERACAO { get; set; }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPAMDS { get; set; }
        public string HISCOBPR_IMPDH { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_TIT_CAPITALIZ { get; set; }
        public string HISCOBPR_VAL_CUSTO_CAPITALI { get; set; }
        public string HISCOBPR_IMPSEGCDG { get; set; }
        public string HISCOBPR_VLCUSTCDG { get; set; }
        public string HISCOBPR_COD_USUARIO { get; set; }
        public string HISCOBPR_TIMESTAMP { get; set; }
        public string HISCOBPR_IMPSEGAUXF { get; set; }
        public string VIND_IMPSEGAUXF { get; set; }
        public string HISCOBPR_VLCUSTAUXF { get; set; }
        public string VIND_VLCUSTAUXF { get; set; }
        public string HISCOBPR_PRMDIT { get; set; }
        public string VIND_PRMDIT { get; set; }
        public string HISCOBPR_QTMDIT { get; set; }
        public string VIND_QTMDIT { get; set; }

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


        public override VA0126B_COBERTURAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0126B_COBERTURAS();
            var i = 0;

            dta.HISCOBPR_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCOBPR_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGUR = result[i++].Value?.ToString();
            dta.HISCOBPR_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGIND = result[i++].Value?.ToString();
            dta.HISCOBPR_COD_OPERACAO = result[i++].Value?.ToString();
            dta.HISCOBPR_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDH = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMVG = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMAP = result[i++].Value?.ToString();
            dta.HISCOBPR_QTDE_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.HISCOBPR_VAL_TIT_CAPITALIZ = result[i++].Value?.ToString();
            dta.HISCOBPR_VAL_CUSTO_CAPITALI = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGCDG = result[i++].Value?.ToString();
            dta.HISCOBPR_VLCUSTCDG = result[i++].Value?.ToString();
            dta.HISCOBPR_COD_USUARIO = result[i++].Value?.ToString();
            dta.HISCOBPR_TIMESTAMP = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.VIND_IMPSEGAUXF = string.IsNullOrWhiteSpace(dta.HISCOBPR_IMPSEGAUXF) ? "-1" : "0";
            dta.HISCOBPR_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.VIND_VLCUSTAUXF = string.IsNullOrWhiteSpace(dta.HISCOBPR_VLCUSTAUXF) ? "-1" : "0";
            dta.HISCOBPR_PRMDIT = result[i++].Value?.ToString();
            dta.VIND_PRMDIT = string.IsNullOrWhiteSpace(dta.HISCOBPR_PRMDIT) ? "-1" : "0";
            dta.HISCOBPR_QTMDIT = result[i++].Value?.ToString();
            dta.VIND_QTMDIT = string.IsNullOrWhiteSpace(dta.HISCOBPR_QTMDIT) ? "-1" : "0";

            return dta;
        }

    }
}