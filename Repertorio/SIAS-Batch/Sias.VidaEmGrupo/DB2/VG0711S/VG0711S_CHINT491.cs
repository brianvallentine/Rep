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
    public class VG0711S_CHINT491 : QueryBasis<VG0711S_CHINT491>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0711S_CHINT491() { IsCursor = true; }

        public VG0711S_CHINT491(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VGARANTI_NUM_GARANTIA { get; set; }
        public string VG087_SEQ_GRUPO_COBERTURA { get; set; }
        public string VGARANTI_TP_GARANTIA { get; set; }
        public string VG091_DES_MSG_HINT { get; set; }

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


        public override VG0711S_CHINT491 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0711S_CHINT491();
            var i = 0;

            dta.VGARANTI_NUM_GARANTIA = result[i++].Value?.ToString();
            dta.VG087_SEQ_GRUPO_COBERTURA = result[i++].Value?.ToString();
            dta.VGARANTI_TP_GARANTIA = result[i++].Value?.ToString();
            dta.VG091_DES_MSG_HINT = result[i++].Value?.ToString();

            return dta;
        }

    }
}