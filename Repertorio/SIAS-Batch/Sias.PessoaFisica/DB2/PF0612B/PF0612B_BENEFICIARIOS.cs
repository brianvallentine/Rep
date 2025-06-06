using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0612B
{
    public class PF0612B_BENEFICIARIOS : QueryBasis<PF0612B_BENEFICIARIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0612B_BENEFICIARIOS() { IsCursor = true; }

        public PF0612B_BENEFICIARIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BENEFPRO_NUM_APOLICE { get; set; }
        public string BENEFPRO_COD_SUBGRUPO { get; set; }
        public string BENEFPRO_COD_FONTE { get; set; }
        public string BENEFPRO_NUM_PROPOSTA { get; set; }
        public string BENEFPRO_NUM_BENEFICIARIO { get; set; }
        public string BENEFPRO_NOME_BENEFICIARIO { get; set; }
        public string BENEFPRO_GRAU_PARENTESCO { get; set; }
        public string BENEFPRO_PCT_PART_BENEFICIA { get; set; }

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


        public override PF0612B_BENEFICIARIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0612B_BENEFICIARIOS();
            var i = 0;

            dta.BENEFPRO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BENEFPRO_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.BENEFPRO_COD_FONTE = result[i++].Value?.ToString();
            dta.BENEFPRO_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.BENEFPRO_NUM_BENEFICIARIO = result[i++].Value?.ToString();
            dta.BENEFPRO_NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.BENEFPRO_GRAU_PARENTESCO = result[i++].Value?.ToString();
            dta.BENEFPRO_PCT_PART_BENEFICIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}