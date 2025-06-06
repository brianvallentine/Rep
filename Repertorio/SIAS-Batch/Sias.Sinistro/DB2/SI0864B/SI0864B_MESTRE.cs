using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class SI0864B_MESTRE : QueryBasis<SI0864B_MESTRE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0864B_MESTRE() { IsCursor = true; }

        public SI0864B_MESTRE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string SINILT01_NUM_APOLICE { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_DTINIVIG { get; set; }
        public string SINILT01_COD_COBERTURA { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }

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


        public override SI0864B_MESTRE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0864B_MESTRE();
            var i = 0;

            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.SINILT01_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.SINILT01_DTINIVIG = result[i++].Value?.ToString();
            dta.SINILT01_COD_COBERTURA = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}