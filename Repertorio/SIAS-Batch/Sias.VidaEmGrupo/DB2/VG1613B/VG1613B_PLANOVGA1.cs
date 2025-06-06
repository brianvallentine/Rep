using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class VG1613B_PLANOVGA1 : QueryBasis<VG1613B_PLANOVGA1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1613B_PLANOVGA1() { IsCursor = true; }

        public VG1613B_PLANOVGA1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PLANOVGA_COD_PLANO { get; set; }
        public string PLANOVGA_DATA_INIVIGENCIA { get; set; }
        public string PLANOVGA_IMP_MORNATU { get; set; }
        public string PLANOVGA_IMP_MORACID { get; set; }
        public string PLANOVGA_IMP_INVPERM { get; set; }
        public string PLANOVGA_IMP_AMDS { get; set; }
        public string PLANOVGA_IMP_DH { get; set; }
        public string PLANOVGA_IMP_DIT { get; set; }

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


        public override VG1613B_PLANOVGA1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1613B_PLANOVGA1();
            var i = 0;

            dta.PLANOVGA_COD_PLANO = result[i++].Value?.ToString();
            dta.PLANOVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_MORNATU = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_MORACID = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_INVPERM = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_AMDS = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_DH = result[i++].Value?.ToString();
            dta.PLANOVGA_IMP_DIT = result[i++].Value?.ToString();

            return dta;
        }

    }
}