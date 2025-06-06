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
    public class R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1 : QueryBasis<R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTD_REGISTROS ,
            PRM_TOTAL ,
            PRM_LIQUIDO ,
            VAL_TARIFA ,
            VAL_BALCAO ,
            VAL_IOCC ,
            VAL_DESCONTO ,
            VAL_JUROS ,
            VAL_MULTA
            INTO :CONDESCE-QTD-REGISTROS ,
            :CONDESCE-PRM-TOTAL ,
            :CONDESCE-PRM-LIQUIDO ,
            :CONDESCE-VAL-TARIFA ,
            :CONDESCE-VAL-BALCAO ,
            :CONDESCE-VAL-IOCC ,
            :CONDESCE-VAL-DESCONTO ,
            :CONDESCE-VAL-JUROS ,
            :CONDESCE-VAL-MULTA
            FROM SEGUROS.CONTROL_DESPES_CEF
            WHERE COD_EMPRESA =
            :CONDESCE-COD-EMPRESA
            AND ANO_REFERENCIA =
            :CONDESCE-ANO-REFERENCIA
            AND MES_REFERENCIA =
            :CONDESCE-MES-REFERENCIA
            AND BCO_AVISO =
            :CONDESCE-BCO-AVISO
            AND AGE_AVISO =
            :CONDESCE-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :CONDESCE-NUM-AVISO-CREDITO
            AND COD_PRODUTO =
            :CONDESCE-COD-PRODUTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTD_REGISTROS 
							,
											PRM_TOTAL 
							,
											PRM_LIQUIDO 
							,
											VAL_TARIFA 
							,
											VAL_BALCAO 
							,
											VAL_IOCC 
							,
											VAL_DESCONTO 
							,
											VAL_JUROS 
							,
											VAL_MULTA
											FROM SEGUROS.CONTROL_DESPES_CEF
											WHERE COD_EMPRESA =
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
        public string CONDESCE_PRM_TOTAL { get; set; }
        public string CONDESCE_PRM_LIQUIDO { get; set; }
        public string CONDESCE_VAL_TARIFA { get; set; }
        public string CONDESCE_VAL_BALCAO { get; set; }
        public string CONDESCE_VAL_IOCC { get; set; }
        public string CONDESCE_VAL_DESCONTO { get; set; }
        public string CONDESCE_VAL_JUROS { get; set; }
        public string CONDESCE_VAL_MULTA { get; set; }
        public string CONDESCE_NUM_AVISO_CREDITO { get; set; }
        public string CONDESCE_ANO_REFERENCIA { get; set; }
        public string CONDESCE_MES_REFERENCIA { get; set; }
        public string CONDESCE_COD_EMPRESA { get; set; }
        public string CONDESCE_COD_PRODUTO { get; set; }
        public string CONDESCE_BCO_AVISO { get; set; }
        public string CONDESCE_AGE_AVISO { get; set; }

        public static R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1 Execute(R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1 r5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1)
        {
            var ths = r5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5100_00_SELECT_CONDESCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDESCE_QTD_REGISTROS = result[i++].Value?.ToString();
            dta.CONDESCE_PRM_TOTAL = result[i++].Value?.ToString();
            dta.CONDESCE_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.CONDESCE_VAL_TARIFA = result[i++].Value?.ToString();
            dta.CONDESCE_VAL_BALCAO = result[i++].Value?.ToString();
            dta.CONDESCE_VAL_IOCC = result[i++].Value?.ToString();
            dta.CONDESCE_VAL_DESCONTO = result[i++].Value?.ToString();
            dta.CONDESCE_VAL_JUROS = result[i++].Value?.ToString();
            dta.CONDESCE_VAL_MULTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}