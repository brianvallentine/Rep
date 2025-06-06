using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class AU2055B_C01_MOVIMCOB : QueryBasis<AU2055B_C01_MOVIMCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AU2055B_C01_MOVIMCOB() { IsCursor = true; }

        public AU2055B_C01_MOVIMCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_ENDOSSO { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_NUM_FITA { get; set; }
        public string MOVIMCOB_DATA_MOVIMENTO { get; set; }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_COD_MOVIMENTO { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string MOVIMCOB_VAL_IOCC { get; set; }
        public string MOVIMCOB_VAL_CREDITO { get; set; }
        public string MOVIMCOB_NOME_SEGURADO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }
        public string PROPOSTA_DATA_INIVIGENCIA { get; set; }
        public string PROPOSTA_NUM_APOL_ANTERIOR { get; set; }

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


        public override AU2055B_C01_MOVIMCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AU2055B_C01_MOVIMCOB();
            var i = 0;

            dta.MOVIMCOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_AVISO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_FITA = result[i++].Value?.ToString();
            dta.MOVIMCOB_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVIMCOB_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_BANCO = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_AGENCIA = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_IOCC = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_CREDITO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.PROPOSTA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PROPOSTA_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}