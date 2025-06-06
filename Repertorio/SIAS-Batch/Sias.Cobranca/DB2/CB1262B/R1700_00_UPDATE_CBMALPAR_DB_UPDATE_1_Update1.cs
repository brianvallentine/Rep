using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1262B
{
    public class R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1 : QueryBasis<R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.CB_MALA_PARCATRASO
				SET
				SITUACAO =  '{this.CBMALPAR_SITUACAO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE 
				NUM_APOLICE =  '{this.PARCEHIS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARCEHIS_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.PARCEHIS_NUM_PARCELA}'
				AND DATA_MOVIMENTO =  '{this.CBMALPAR_DATA_MOVIMENTO}'";

            return query;
        }
        public string CBMALPAR_SITUACAO { get; set; }
        public string CBMALPAR_DATA_MOVIMENTO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static void Execute(R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1 r1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1)
        {
            var ths = r1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1700_00_UPDATE_CBMALPAR_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}