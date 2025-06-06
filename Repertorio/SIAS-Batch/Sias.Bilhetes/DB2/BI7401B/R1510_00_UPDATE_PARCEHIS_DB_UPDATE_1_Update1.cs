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
    public class R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 : QueryBasis<R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.PARCELA_HISTORICO
				SET BCO_COBRANCA =  '{this.PARCEHIS_BCO_COBRANCA}'
				,AGE_COBRANCA =  '{this.PARCEHIS_AGE_COBRANCA}'
				,NUM_AVISO_CREDITO =  '{this.PARCEHIS_NUM_AVISO_CREDITO}'
				WHERE  NUM_APOLICE =  '{this.PARCEHIS_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.PARCEHIS_NUM_ENDOSSO}'
				AND NUM_PARCELA =  '{this.PARCEHIS_NUM_PARCELA}'
				AND OCORR_HISTORICO =  '{this.PARCEHIS_OCORR_HISTORICO}'";

            return query;
        }
        public string PARCEHIS_NUM_AVISO_CREDITO { get; set; }
        public string PARCEHIS_BCO_COBRANCA { get; set; }
        public string PARCEHIS_AGE_COBRANCA { get; set; }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

        public static void Execute(R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 r1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1)
        {
            var ths = r1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1510_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}