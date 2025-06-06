using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PRODUTO,
            A.COD_FONTE,
            B.ORGAO_EMISSOR,
            B.COD_CLIENTE
            INTO :ENDOSSOS-COD-PRODUTO,
            :ENDOSSOS-COD-FONTE,
            :APOLICES-ORGAO-EMISSOR,
            :APOLICES-COD-CLIENTE
            FROM SEGUROS.ENDOSSOS A,
            SEGUROS.APOLICES B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND A.NUM_ENDOSSO = :APOLIAUT-NUM-ENDOSSO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.COD_PRODUTO
							,
											A.COD_FONTE
							,
											B.ORGAO_EMISSOR
							,
											B.COD_CLIENTE
											FROM SEGUROS.ENDOSSOS A
							,
											SEGUROS.APOLICES B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.APOLIAUT_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string APOLIAUT_NUM_ENDOSSO { get; set; }

        public static R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1 r1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_LE_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}