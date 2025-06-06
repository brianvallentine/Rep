using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 : QueryBasis<R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.PARCELAS
				SET SIT_REGISTRO = '2'
				,OCORR_HISTORICO =  '{this.PARCEHIS_OCORR_HISTORICO}'
				WHERE  NUM_APOLICE =  '{this.PARCEHIS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARCEHIS_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.PARCEHIS_NUM_PARCELA}'";

            return query;
        }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static void Execute(R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 r1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1)
        {
            var ths = r1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1560_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}