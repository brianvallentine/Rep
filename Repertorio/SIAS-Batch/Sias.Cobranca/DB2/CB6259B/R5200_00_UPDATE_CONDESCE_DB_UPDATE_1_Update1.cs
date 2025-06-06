using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6259B
{
    public class R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1 : QueryBasis<R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CONTROL_DESPES_CEF
				SET QTD_REGISTROS =
				 '{this.CONDESCE_QTD_REGISTROS}' ,
				PRM_TOTAL =
				 '{this.CONDESCE_PRM_TOTAL}' ,
				PRM_LIQUIDO =
				 '{this.CONDESCE_PRM_LIQUIDO}' ,
				VAL_TARIFA =
				 '{this.CONDESCE_VAL_TARIFA}' ,
				VAL_BALCAO =
				 '{this.CONDESCE_VAL_BALCAO}' ,
				VAL_IOCC =
				 '{this.CONDESCE_VAL_IOCC}' ,
				VAL_DESCONTO =
				 '{this.CONDESCE_VAL_DESCONTO}' ,
				VAL_JUROS =
				 '{this.CONDESCE_VAL_JUROS}' ,
				VAL_MULTA =
				 '{this.CONDESCE_VAL_MULTA}'
				WHERE  COD_EMPRESA =
				 '{this.CONDESCE_COD_EMPRESA}'
				AND ANO_REFERENCIA =
				 '{this.CONDESCE_ANO_REFERENCIA}'
				AND MES_REFERENCIA =
				 '{this.CONDESCE_MES_REFERENCIA}'
				AND BCO_AVISO =
				 '{this.CONDESCE_BCO_AVISO}'
				AND AGE_AVISO =
				 '{this.CONDESCE_AGE_AVISO}'
				AND NUM_AVISO_CREDITO =
				 '{this.CONDESCE_NUM_AVISO_CREDITO}'
				AND COD_PRODUTO =
				 '{this.CONDESCE_COD_PRODUTO}'";

            return query;
        }
        public string CONDESCE_QTD_REGISTROS { get; set; }
        public string CONDESCE_VAL_DESCONTO { get; set; }
        public string CONDESCE_PRM_LIQUIDO { get; set; }
        public string CONDESCE_VAL_TARIFA { get; set; }
        public string CONDESCE_VAL_BALCAO { get; set; }
        public string CONDESCE_PRM_TOTAL { get; set; }
        public string CONDESCE_VAL_JUROS { get; set; }
        public string CONDESCE_VAL_MULTA { get; set; }
        public string CONDESCE_VAL_IOCC { get; set; }
        public string CONDESCE_NUM_AVISO_CREDITO { get; set; }
        public string CONDESCE_ANO_REFERENCIA { get; set; }
        public string CONDESCE_MES_REFERENCIA { get; set; }
        public string CONDESCE_COD_EMPRESA { get; set; }
        public string CONDESCE_COD_PRODUTO { get; set; }
        public string CONDESCE_BCO_AVISO { get; set; }
        public string CONDESCE_AGE_AVISO { get; set; }

        public static void Execute(R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1 r5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1)
        {
            var ths = r5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5200_00_UPDATE_CONDESCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}