using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class SI0888B_CR_ESTORNO : QueryBasis<SI0888B_CR_ESTORNO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0888B_CR_ESTORNO() { IsCursor = true; }

        public SI0888B_CR_ESTORNO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_RAMO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }

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


        public override SI0888B_CR_ESTORNO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0888B_CR_ESTORNO();
            var i = 0;

            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GESISFUO_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GESISFUO_COD_FUNCAO = result[i++].Value?.ToString();
            dta.GESISFUO_IDE_SISTEMA_OPER = result[i++].Value?.ToString();

            return dta;
        }

    }
}