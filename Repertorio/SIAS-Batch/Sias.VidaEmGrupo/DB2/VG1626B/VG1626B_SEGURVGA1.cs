using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class VG1626B_SEGURVGA1 : QueryBasis<VG1626B_SEGURVGA1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1626B_SEGURVGA1() { IsCursor = true; }

        public VG1626B_SEGURVGA1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }

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


        public override VG1626B_SEGURVGA1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1626B_SEGURVGA1();
            var i = 0;

            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();

            return dta;
        }

    }
}