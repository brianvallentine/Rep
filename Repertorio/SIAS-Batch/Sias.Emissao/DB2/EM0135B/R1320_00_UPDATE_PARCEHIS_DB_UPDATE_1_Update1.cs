using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0135B
{
    public class R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 : QueryBasis<R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELA_HISTORICO
				SET DATA_VENCIMENTO =  '{this.V1SIST_DTMOVABE}'
				WHERE  NUM_APOLICE =  '{this.ENDOSSOS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.ENDOSSOS_NUM_ENDOSSO}'
				AND NUM_PARCELA = 0";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static void Execute(R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 r1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1)
        {
            var ths = r1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1320_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}