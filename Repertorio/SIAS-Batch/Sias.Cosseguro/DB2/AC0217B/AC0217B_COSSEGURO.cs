using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0217B
{
    public class AC0217B_COSSEGURO : QueryBasis<AC0217B_COSSEGURO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0217B_COSSEGURO() { IsCursor = true; }

        public AC0217B_COSSEGURO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COSHISSI_NUM_SINISTRO { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string COSHISSI_COD_CONGENERE { get; set; }
        public string COSHISSI_OCORR_HISTORICO { get; set; }
        public string COSHISSI_COD_OPERACAO { get; set; }
        public string COSHISSI_VAL_OPERACAO { get; set; }
        public string COSHISSI_TIPO_SEGURO { get; set; }
        public string COSHISSI_DATA_MOVIMENTO { get; set; }
        public string GESISFUO_NUM_FATOR { get; set; }

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


        public override AC0217B_COSSEGURO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0217B_COSSEGURO();
            var i = 0;

            dta.COSHISSI_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.GESISFUO_COD_FUNCAO = result[i++].Value?.ToString();
            dta.COSHISSI_COD_CONGENERE = result[i++].Value?.ToString();
            dta.COSHISSI_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.COSHISSI_COD_OPERACAO = result[i++].Value?.ToString();
            dta.COSHISSI_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.COSHISSI_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.COSHISSI_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.GESISFUO_NUM_FATOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}