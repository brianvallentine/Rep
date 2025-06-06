using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1 : QueryBasis<R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PD.COD_EMPRESA
            INTO :PRODUTO-COD-EMPRESA
            FROM SEGUROS.PRODUTO PD
            WHERE PD.COD_PRODUTO = :APOLICES-COD-PRODUTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PD.COD_EMPRESA
											FROM SEGUROS.PRODUTO PD
											WHERE PD.COD_PRODUTO = '{this.APOLICES_COD_PRODUTO}'";

            return query;
        }
        public string PRODUTO_COD_EMPRESA { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }

        public static R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1 Execute(R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1 r6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1)
        {
            var ths = r6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}