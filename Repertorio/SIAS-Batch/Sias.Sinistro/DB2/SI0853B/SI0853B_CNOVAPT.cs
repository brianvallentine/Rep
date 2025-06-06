using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0853B
{
    public class SI0853B_CNOVAPT : QueryBasis<SI0853B_CNOVAPT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0853B_CNOVAPT() { IsCursor = true; }

        public SI0853B_CNOVAPT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string APOLIAUT_NUM_ITEM { get; set; }
        public string APOLIAUT_ANO_FABRICACAO { get; set; }
        public string APOLIAUT_ANO_MODELO { get; set; }
        public string APOLIAUT_PLACA_UF { get; set; }
        public string APOLIAUT_PLACA_LETRA { get; set; }
        public string APOLIAUT_PLACA_NUMERO { get; set; }
        public string APOLIAUT_NUM_CHASSIS { get; set; }
        public string APOLIAUT_COD_CLIENTE { get; set; }
        public string APOLIAUT_COD_VEICULO { get; set; }
        public string APOLIAUT_COD_FABRICANTE { get; set; }
        public string APOLIAUT_NUM_PRM_RESSEGURO { get; set; }

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


        public override SI0853B_CNOVAPT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0853B_CNOVAPT();
            var i = 0;

            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.APOLIAUT_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLIAUT_ANO_FABRICACAO = result[i++].Value?.ToString();
            dta.APOLIAUT_ANO_MODELO = result[i++].Value?.ToString();
            dta.APOLIAUT_PLACA_UF = result[i++].Value?.ToString();
            dta.APOLIAUT_PLACA_LETRA = result[i++].Value?.ToString();
            dta.APOLIAUT_PLACA_NUMERO = result[i++].Value?.ToString();
            dta.APOLIAUT_NUM_CHASSIS = result[i++].Value?.ToString();
            dta.APOLIAUT_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOLIAUT_COD_VEICULO = result[i++].Value?.ToString();
            dta.APOLIAUT_COD_FABRICANTE = result[i++].Value?.ToString();
            dta.APOLIAUT_NUM_PRM_RESSEGURO = result[i++].Value?.ToString();

            return dta;
        }

    }
}