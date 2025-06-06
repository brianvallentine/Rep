using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0134B
{
    public class VG0134B_CRELAT : QueryBasis<VG0134B_CRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0134B_CRELAT() { IsCursor = true; }

        public VG0134B_CRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_ANO_REFERENCIA { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string WS_DATA_AUX { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_COD_PLANO { get; set; }

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


        public override VG0134B_CRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0134B_CRELAT();
            var i = 0;

            dta.RELATORI_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.WS_DATA_AUX = result[i++].Value?.ToString();
            dta.RELATORI_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.RELATORI_COD_PLANO = result[i++].Value?.ToString();

            return dta;
        }

    }
}