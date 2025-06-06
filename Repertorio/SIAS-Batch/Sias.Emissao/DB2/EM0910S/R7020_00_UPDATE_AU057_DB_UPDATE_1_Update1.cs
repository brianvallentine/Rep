using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1 : QueryBasis<R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AU_PROP_CONV_VC
				SET IND_OPERACAO =  '{this.AU057_IND_OPERACAO}',
				COD_FONTE =  '{this.AU057_COD_FONTE}',
				NUM_PROPOSTA =  '{this.AU057_NUM_PROPOSTA}',
				NUM_APOLICE =  '{this.AU057_NUM_APOLICE}',
				NUM_ENDOSSO =  '{this.AU057_NUM_ENDOSSO}',
				COD_TIPO_ENDOSSO =  '{this.AU057_COD_TIPO_ENDOSSO}'
				WHERE  NUM_PROPOSTA_VC =  '{this.AU057_NUM_PROPOSTA_VC}'
				AND COD_CONGENERE =  '{this.AU057_COD_CONGENERE}'";

            return query;
        }
        public string AU057_COD_TIPO_ENDOSSO { get; set; }
        public string AU057_IND_OPERACAO { get; set; }
        public string AU057_NUM_PROPOSTA { get; set; }
        public string AU057_NUM_APOLICE { get; set; }
        public string AU057_NUM_ENDOSSO { get; set; }
        public string AU057_COD_FONTE { get; set; }
        public string AU057_NUM_PROPOSTA_VC { get; set; }
        public string AU057_COD_CONGENERE { get; set; }

        public static void Execute(R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1 r7020_00_UPDATE_AU057_DB_UPDATE_1_Update1)
        {
            var ths = r7020_00_UPDATE_AU057_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}