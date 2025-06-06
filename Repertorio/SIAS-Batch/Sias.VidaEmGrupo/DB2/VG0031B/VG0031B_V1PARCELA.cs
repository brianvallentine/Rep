using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class VG0031B_V1PARCELA : QueryBasis<VG0031B_V1PARCELA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0031B_V1PARCELA() { IsCursor = true; }

        public VG0031B_V1PARCELA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_DACPARC { get; set; }
        public string V1PARC_FONTE { get; set; }
        public string V1PARC_NRTIT { get; set; }
        public string V1PARC_OCORHIST { get; set; }
        public string V1PARC_QTDDOC { get; set; }
        public string V1PARC_SITUACAO { get; set; }
        public string V1PARC_COD_EMP { get; set; }
        public string VIND_COD_EMP { get; set; }

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


        public override VG0031B_V1PARCELA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0031B_V1PARCELA();
            var i = 0;

            dta.V1PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1PARC_DACPARC = result[i++].Value?.ToString();
            dta.V1PARC_FONTE = result[i++].Value?.ToString();
            dta.V1PARC_NRTIT = result[i++].Value?.ToString();
            dta.V1PARC_OCORHIST = result[i++].Value?.ToString();
            dta.V1PARC_QTDDOC = result[i++].Value?.ToString();
            dta.V1PARC_SITUACAO = result[i++].Value?.ToString();
            dta.V1PARC_COD_EMP = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V1PARC_COD_EMP) ? "-1" : "0";

            return dta;
        }

    }
}