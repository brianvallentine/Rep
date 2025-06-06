using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class VG0853B_CTERMO1 : QueryBasis<VG0853B_CTERMO1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0853B_CTERMO1() { IsCursor = true; }

        public VG0853B_CTERMO1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TERMOADE_NUM_APOLICE { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

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


        public override VG0853B_CTERMO1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0853B_CTERMO1();
            var i = 0;

            dta.TERMOADE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.TERMOADE_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}