using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class VE0414B_CRELAT : QueryBasis<VE0414B_CRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0414B_CRELAT() { IsCursor = true; }

        public VE0414B_CRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLRELATORIOS_RELATORI_NUM_TITULO { get; set; }
        public string DCLRELATORIOS_RELATORI_NUM_APOLICE { get; set; }
        public string DCLRELATORIOS_RELATORI_COD_SUBGRUPO { get; set; }

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


        public override VE0414B_CRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0414B_CRELAT();
            var i = 0;

            dta.DCLRELATORIOS_RELATORI_NUM_TITULO = result[i++].Value?.ToString();
            dta.DCLRELATORIOS_RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.DCLRELATORIOS_RELATORI_COD_SUBGRUPO = result[i++].Value?.ToString();

            return dta;
        }

    }
}