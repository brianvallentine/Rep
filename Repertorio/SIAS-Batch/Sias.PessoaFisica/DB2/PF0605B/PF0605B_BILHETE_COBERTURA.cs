using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class PF0605B_BILHETE_COBERTURA : QueryBasis<PF0605B_BILHETE_COBERTURA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0605B_BILHETE_COBERTURA() { IsCursor = true; }

        public PF0605B_BILHETE_COBERTURA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILCOBER_COD_PRODUTO { get; set; }
        public string BILCOBER_RAMO_COBERTURA { get; set; }
        public string BILCOBER_MODALI_COBERTURA { get; set; }
        public string BILCOBER_COD_OPCAO_PLANO { get; set; }
        public string BILCOBER_COD_COBERTURA { get; set; }
        public string BILCOBER_DATA_INIVIGENCIA { get; set; }
        public string BILCOBER_DATA_TERVIGENCIA { get; set; }
        public string BILCOBER_IDE_COBERTURA { get; set; }
        public string BILCOBER_VAL_COBERTURA_IX { get; set; }
        public string BILCOBER_PRM_TOTAL { get; set; }
        public string BILCOBER_PCT_IOCC { get; set; }

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


        public override PF0605B_BILHETE_COBERTURA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0605B_BILHETE_COBERTURA();
            var i = 0;

            dta.BILCOBER_COD_PRODUTO = result[i++].Value?.ToString();
            dta.BILCOBER_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.BILCOBER_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.BILCOBER_COD_OPCAO_PLANO = result[i++].Value?.ToString();
            dta.BILCOBER_COD_COBERTURA = result[i++].Value?.ToString();
            dta.BILCOBER_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.BILCOBER_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.BILCOBER_IDE_COBERTURA = result[i++].Value?.ToString();
            dta.BILCOBER_VAL_COBERTURA_IX = result[i++].Value?.ToString();
            dta.BILCOBER_PRM_TOTAL = result[i++].Value?.ToString();
            dta.BILCOBER_PCT_IOCC = result[i++].Value?.ToString();

            return dta;
        }

    }
}