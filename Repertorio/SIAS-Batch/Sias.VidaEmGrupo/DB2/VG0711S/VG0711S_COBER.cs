using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class VG0711S_COBER : QueryBasis<VG0711S_COBER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0711S_COBER() { IsCursor = true; }

        public VG0711S_COBER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string VGCOBSUB_IMP_SEGURADA_IX { get; set; }
        public string VGCOBSUB_DATA_INIVIGENCIA { get; set; }
        public string VG033_DES_ACESSORIO { get; set; }

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


        public override VG0711S_COBER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0711S_COBER();
            var i = 0;

            dta.VGCOBSUB_COD_COBERTURA = result[i++].Value?.ToString();
            dta.VGCOBSUB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.VGCOBSUB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.VG033_DES_ACESSORIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}