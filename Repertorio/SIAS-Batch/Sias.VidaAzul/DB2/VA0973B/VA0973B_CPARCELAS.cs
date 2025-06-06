using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0973B
{
    public class VA0973B_CPARCELAS : QueryBasis<VA0973B_CPARCELAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0973B_CPARCELAS() { IsCursor = true; }

        public VA0973B_CPARCELAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string WS_HOST_DES_SITU { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string GE407_COD_IDLG { get; set; }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string GE408_DTA_CREDITO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }

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


        public override VA0973B_CPARCELAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0973B_CPARCELAS();
            var i = 0;

            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.WS_HOST_DES_SITU = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.GE407_COD_IDLG = result[i++].Value?.ToString();
            dta.PARCEVID_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.GE408_DTA_CREDITO = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();

            return dta;
        }

    }
}