using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0032B
{
    public class VG0032B_TMOVIMENTO : QueryBasis<VG0032B_TMOVIMENTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0032B_TMOVIMENTO() { IsCursor = true; }

        public VG0032B_TMOVIMENTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }

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


        public override VG0032B_TMOVIMENTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0032B_TMOVIMENTO();
            var i = 0;

            dta.SEGURVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}