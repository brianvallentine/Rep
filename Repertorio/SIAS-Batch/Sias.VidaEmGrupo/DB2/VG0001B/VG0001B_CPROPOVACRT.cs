using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class VG0001B_CPROPOVACRT : QueryBasis<VG0001B_CPROPOVACRT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0001B_CPROPOVACRT() { IsCursor = true; }

        public VG0001B_CPROPOVACRT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_TITULO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGSOLFAT_PRM_VG { get; set; }
        public string VGSOLFAT_PRM_AP { get; set; }
        public string VGSOLFAT_PRM_TOTAL { get; set; }

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


        public override VG0001B_CPROPOVACRT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0001B_CPROPOVACRT();
            var i = 0;

            dta.VGSOLFAT_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VGSOLFAT_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.VGSOLFAT_NUM_TITULO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.CONVERSI_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGSOLFAT_PRM_VG = result[i++].Value?.ToString();
            dta.VGSOLFAT_PRM_AP = result[i++].Value?.ToString();
            dta.VGSOLFAT_PRM_TOTAL = result[i++].Value?.ToString();

            return dta;
        }

    }
}