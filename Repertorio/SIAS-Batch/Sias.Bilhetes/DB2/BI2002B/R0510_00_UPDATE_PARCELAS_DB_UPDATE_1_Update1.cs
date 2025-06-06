using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 : QueryBasis<R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.PARCELAS
				SET OCORR_HISTORICO =  '{this.PARCEHIS_OCORR_HISTORICO}'
				,SIT_REGISTRO = '1'
				WHERE  NUM_APOLICE =  '{this.CBCONDEV_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.CBCONDEV_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.CBCONDEV_NUM_PARCELA}'";

            return query;
        }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string CBCONDEV_NUM_APOLICE { get; set; }
        public string CBCONDEV_NUM_ENDOSSO { get; set; }
        public string CBCONDEV_NUM_PARCELA { get; set; }

        public static void Execute(R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 r0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1)
        {
            var ths = r0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}