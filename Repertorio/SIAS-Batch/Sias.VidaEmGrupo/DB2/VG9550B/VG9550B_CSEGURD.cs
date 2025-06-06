using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9550B
{
    public class VG9550B_CSEGURD : QueryBasis<VG9550B_CSEGURD>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG9550B_CSEGURD() { IsCursor = true; }

        public VG9550B_CSEGURD(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_OCORR_END_COBRAN { get; set; }

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


        public override VG9550B_CSEGURD OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG9550B_CSEGURD();
            var i = 0;

            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_END_COBRAN = result[i++].Value?.ToString();

            return dta;
        }

    }
}