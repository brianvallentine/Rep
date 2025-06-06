using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE ,
            ORGAO_EMISSOR
            INTO :APOLICES-COD-CLIENTE ,
            :APOLICES-ORGAO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE 
							,
											ORGAO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1 r0310_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r0310_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0310_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}