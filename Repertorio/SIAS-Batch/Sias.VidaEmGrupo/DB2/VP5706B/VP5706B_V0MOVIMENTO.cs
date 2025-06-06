using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP5706B
{
    public class VP5706B_V0MOVIMENTO : QueryBasis<VP5706B_V0MOVIMENTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP5706B_V0MOVIMENTO() { IsCursor = true; }

        public VP5706B_V0MOVIMENTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SQL_NUM_APOL { get; set; }
        public string SQL_COD_SUB { get; set; }
        public string SQL_COD_FONTE { get; set; }
        public string SQL_PROPOSTA { get; set; }
        public string SQL_TIPO_SEG { get; set; }
        public string SQL_NUM_CERT { get; set; }
        public string SQL_DAC_CERT { get; set; }
        public string SQL_COD_CLIE { get; set; }
        public string SQL_COD_AGEN { get; set; }
        public string SQL_MATRICULA { get; set; }
        public string SQL_PRM_VG { get; set; }
        public string SQL_PRM_AP { get; set; }
        public string SQL_COD_OPERAC { get; set; }
        public string SQL_FAIXA { get; set; }
        public string SQL_PERC_COMIS { get; set; }
        public string SQL_NRPARCEL { get; set; }
        public string SQL_DTMOVTO { get; set; }
        public string SQL_SITUACAO { get; set; }

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


        public override VP5706B_V0MOVIMENTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP5706B_V0MOVIMENTO();
            var i = 0;

            dta.SQL_NUM_APOL = result[i++].Value?.ToString();
            dta.SQL_COD_SUB = result[i++].Value?.ToString();
            dta.SQL_COD_FONTE = result[i++].Value?.ToString();
            dta.SQL_PROPOSTA = result[i++].Value?.ToString();
            dta.SQL_TIPO_SEG = result[i++].Value?.ToString();
            dta.SQL_NUM_CERT = result[i++].Value?.ToString();
            dta.SQL_DAC_CERT = result[i++].Value?.ToString();
            dta.SQL_COD_CLIE = result[i++].Value?.ToString();
            dta.SQL_COD_AGEN = result[i++].Value?.ToString();
            dta.SQL_MATRICULA = result[i++].Value?.ToString();
            dta.SQL_PRM_VG = result[i++].Value?.ToString();
            dta.SQL_PRM_AP = result[i++].Value?.ToString();
            dta.SQL_COD_OPERAC = result[i++].Value?.ToString();
            dta.SQL_FAIXA = result[i++].Value?.ToString();
            dta.SQL_PERC_COMIS = result[i++].Value?.ToString();
            dta.SQL_NRPARCEL = result[i++].Value?.ToString();
            dta.SQL_DTMOVTO = result[i++].Value?.ToString();
            dta.SQL_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}