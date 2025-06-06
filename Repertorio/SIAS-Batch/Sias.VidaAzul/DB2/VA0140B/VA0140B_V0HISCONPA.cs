using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class VA0140B_V0HISCONPA : QueryBasis<VA0140B_V0HISCONPA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0140B_V0HISCONPA() { IsCursor = true; }

        public VA0140B_V0HISCONPA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_COD_FONTE { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }
        public string HISCONPA_DATA_MOVIMENTO { get; set; }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string HISCONPA_COD_OPERACAO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_ESTR_COBR { get; set; }
        public string VIND_NULL02 { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string VIND_NULL03 { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string WHOST_DATAMES1 { get; set; }

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


        public override VA0140B_V0HISCONPA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0140B_V0HISCONPA();
            var i = 0;

            dta.HISCONPA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_TITULO = result[i++].Value?.ToString();
            dta.HISCONPA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.HISCONPA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.HISCONPA_COD_FONTE = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_VG = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_AP = result[i++].Value?.ToString();
            dta.HISCONPA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.HISCONPA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.HISCONPA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_ESTR_COBR = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.PRODUVG_ESTR_COBR) ? "-1" : "0";
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.PRODUVG_ORIG_PRODU) ? "-1" : "0";
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WHOST_DATAMES1 = result[i++].Value?.ToString();

            return dta;
        }

    }
}