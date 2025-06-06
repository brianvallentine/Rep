using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class VG0133B_RELATORIO : QueryBasis<VG0133B_RELATORIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0133B_RELATORIO() { IsCursor = true; }

        public VG0133B_RELATORIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string R_NUM_APOLICE { get; set; }
        public string R_COD_SUBGRUPO { get; set; }
        public string R_IMP_MORNATU { get; set; }
        public string R_IMP_MORACID { get; set; }
        public string R_IMP_INVPERM { get; set; }
        public string R_IMP_AMDS { get; set; }
        public string R_IMP_DH { get; set; }
        public string R_IMP_DIT { get; set; }
        public string R_PRM_VG { get; set; }
        public string R_PRM_AP { get; set; }
        public string R_DATA_AUMENTO { get; set; }
        public string R_COD_USUARIO { get; set; }

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


        public override VG0133B_RELATORIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0133B_RELATORIO();
            var i = 0;

            dta.R_NUM_APOLICE = result[i++].Value?.ToString();
            dta.R_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.R_IMP_MORNATU = result[i++].Value?.ToString();
            dta.R_IMP_MORACID = result[i++].Value?.ToString();
            dta.R_IMP_INVPERM = result[i++].Value?.ToString();
            dta.R_IMP_AMDS = result[i++].Value?.ToString();
            dta.R_IMP_DH = result[i++].Value?.ToString();
            dta.R_IMP_DIT = result[i++].Value?.ToString();
            dta.R_PRM_VG = result[i++].Value?.ToString();
            dta.R_PRM_AP = result[i++].Value?.ToString();
            dta.R_DATA_AUMENTO = result[i++].Value?.ToString();
            dta.R_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}