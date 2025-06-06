using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            ORGAO_EMISSOR,
            RAMO_EMISSOR
            INTO :APOLICES-NUM-APOLICE ,
            :APOLICES-ORGAO-EMISSOR,
            :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											ORGAO_EMISSOR
							,
											RAMO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }

        public static R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1 r1477_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r1477_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1477_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}