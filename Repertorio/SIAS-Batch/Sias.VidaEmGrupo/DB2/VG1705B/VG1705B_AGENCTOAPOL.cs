using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class VG1705B_AGENCTOAPOL : QueryBasis<VG1705B_AGENCTOAPOL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1705B_AGENCTOAPOL() { IsCursor = true; }

        public VG1705B_AGENCTOAPOL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string AGEAPOVG_NUM_APOLICE { get; set; }
        public string AGEAPOVG_COD_SUBGRUPO { get; set; }
        public string AGEAPOVG_NUM_PARCELA { get; set; }
        public string AGEAPOVG_COD_AGENCIADOR { get; set; }
        public string AGEAPOVG_MATRIC_INDICADOR { get; set; }
        public string AGEAPOVG_PERC_PAG_PARCELA { get; set; }
        public string AGEAPOVG_COD_PAG_ANGARIACAO { get; set; }
        public string AGEAPOVG_NUM_ENDOSSO { get; set; }
        public string AGEAPOVG_DATA_MOVIMENTO { get; set; }
        public string AGEAPOVG_SITUACAO_AGENCTO { get; set; }
        public string AGEAPOVG_TIMESTAMP { get; set; }

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


        public override VG1705B_AGENCTOAPOL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1705B_AGENCTOAPOL();
            var i = 0;

            dta.AGEAPOVG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.AGEAPOVG_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.AGEAPOVG_NUM_PARCELA = result[i++].Value?.ToString();
            dta.AGEAPOVG_COD_AGENCIADOR = result[i++].Value?.ToString();
            dta.AGEAPOVG_MATRIC_INDICADOR = result[i++].Value?.ToString();
            dta.AGEAPOVG_PERC_PAG_PARCELA = result[i++].Value?.ToString();
            dta.AGEAPOVG_COD_PAG_ANGARIACAO = result[i++].Value?.ToString();
            dta.AGEAPOVG_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.AGEAPOVG_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.AGEAPOVG_SITUACAO_AGENCTO = result[i++].Value?.ToString();
            dta.AGEAPOVG_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}