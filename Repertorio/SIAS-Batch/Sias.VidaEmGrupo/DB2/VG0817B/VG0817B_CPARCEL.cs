using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0817B
{
    public class VG0817B_CPARCEL : QueryBasis<VG0817B_CPARCEL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0817B_CPARCEL() { IsCursor = true; }

        public VG0817B_CPARCEL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PARC_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_PRMTOT { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_SITUACAO { get; set; }
        public string V0SUBG_TIPO_FATURAMENTO { get; set; }
        public string V0SUBG_PERI_FATURAMENTO { get; set; }

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


        public override VG0817B_CPARCEL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0817B_CPARCEL();
            var i = 0;

            dta.V0PARC_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PARC_PRMTOT = result[i++].Value?.ToString();
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_SITUACAO = result[i++].Value?.ToString();
            dta.V0SUBG_TIPO_FATURAMENTO = result[i++].Value?.ToString();
            dta.V0SUBG_PERI_FATURAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}