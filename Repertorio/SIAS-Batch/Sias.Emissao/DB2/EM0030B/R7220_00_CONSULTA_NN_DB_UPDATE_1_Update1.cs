using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1 : QueryBasis<R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS
				SET NUM_TITULO =  '{this.PARC_NRTIT}'
				WHERE  NUM_APOLICE =  '{this.PARC_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARC_NRENDOS}'
				AND NUM_PARCELA =  '{this.PARC_NRPARCEL}'";

            return query;
        }
        public string PARC_NRTIT { get; set; }
        public string PARC_NUM_APOLICE { get; set; }
        public string PARC_NRPARCEL { get; set; }
        public string PARC_NRENDOS { get; set; }

        public static void Execute(R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1 r7220_00_CONSULTA_NN_DB_UPDATE_1_Update1)
        {
            var ths = r7220_00_CONSULTA_NN_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}