using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class VG0852B_CHISTCB : QueryBasis<VG0852B_CHISTCB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0852B_CHISTCB() { IsCursor = true; }

        public VG0852B_CHISTCB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string SUBGVGAP_TIPO_FATURAMENTO { get; set; }

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


        public override VG0852B_CHISTCB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0852B_CHISTCB();
            var i = 0;

            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_FATURAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}