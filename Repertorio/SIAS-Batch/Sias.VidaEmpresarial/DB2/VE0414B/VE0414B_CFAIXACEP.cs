using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class VE0414B_CFAIXACEP : QueryBasis<VE0414B_CFAIXACEP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0414B_CFAIXACEP() { IsCursor = true; }

        public VE0414B_CFAIXACEP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLGE_FAIXA_CEP_GEFAICEP_FAIXA { get; set; }
        public string DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL { get; set; }
        public string DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL { get; set; }
        public string DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA { get; set; }
        public string DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR { get; set; }

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


        public override VE0414B_CFAIXACEP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0414B_CFAIXACEP();
            var i = 0;

            dta.DCLGE_FAIXA_CEP_GEFAICEP_FAIXA = result[i++].Value?.ToString();
            dta.DCLGE_FAIXA_CEP_GEFAICEP_CEP_INICIAL = result[i++].Value?.ToString();
            dta.DCLGE_FAIXA_CEP_GEFAICEP_CEP_FINAL = result[i++].Value?.ToString();
            dta.DCLGE_FAIXA_CEP_GEFAICEP_DESCRICAO_FAIXA = result[i++].Value?.ToString();
            dta.DCLGE_FAIXA_CEP_GEFAICEP_CENTRALIZADOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}