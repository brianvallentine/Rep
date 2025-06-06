using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB7537B
{
    public class CB7537B_V0MOVICOB : QueryBasis<CB7537B_V0MOVICOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB7537B_V0MOVICOB() { IsCursor = true; }

        public CB7537B_V0MOVICOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string MOVIMCOB_DATA_QUITACAO { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_PARCELA { get; set; }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string MOVIMCOB_VAL_CREDITO { get; set; }

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


        public override CB7537B_V0MOVICOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB7537B_V0MOVICOB();
            var i = 0;

            dta.MOVIMCOB_COD_BANCO = result[i++].Value?.ToString();
            dta.MOVIMCOB_COD_AGENCIA = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_AVISO = result[i++].Value?.ToString();
            dta.MOVIMCOB_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMCOB_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_TITULO = result[i++].Value?.ToString();
            dta.MOVIMCOB_VAL_CREDITO = result[i++].Value?.ToString();

            return dta;
        }

    }
}