using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class VG1705B_FATURASC : QueryBasis<VG1705B_FATURASC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1705B_FATURASC() { IsCursor = true; }

        public VG1705B_FATURASC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FATURAS_NUM_FATURA { get; set; }
        public string FATURAS_NUM_ENDOSSO { get; set; }

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


        public override VG1705B_FATURASC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1705B_FATURASC();
            var i = 0;

            dta.FATURAS_NUM_FATURA = result[i++].Value?.ToString();
            dta.FATURAS_NUM_ENDOSSO = result[i++].Value?.ToString();

            return dta;
        }

    }
}