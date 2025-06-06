using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class BI6252B_V0MOVIMCOB : QueryBasis<BI6252B_V0MOVIMCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI6252B_V0MOVIMCOB() { IsCursor = true; }

        public BI6252B_V0MOVIMCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVIMCOB_COD_EMPRESA { get; set; }
        public string MOVIMCOB_COD_MOVIMENTO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_NUM_FITA { get; set; }
        public string MOVIMCOB_DATA_MOVIMENTO { get; set; }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string MOVIMCOB_VAL_CREDITO { get; set; }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NOME_SEGURADO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string MOVIMCOB_TIPO_MOVIMENTO { get; set; }
        public string WSGER00_DATA_INIVIGENCIA { get; set; }
        public string WSGER00_DATA_TERVIGENCIA { get; set; }
        public string WSGER00_DATA_VENCIMENTO { get; set; }

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


        public override BI6252B_V0MOVIMCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI6252B_V0MOVIMCOB();
            var i = 0;

            dta.MOVIMCOB_COD_EMPRESA = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_BANCO = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_AGENCIA = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_AVISO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_FITA = result[i++].Value?.ToString();
            dta.MOVIMCOB_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVIMCOB_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_CREDITO = result[i++].Value?.ToString();
            dta.MOVIMCOB_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.WSGER00_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER00_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER00_DATA_VENCIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}