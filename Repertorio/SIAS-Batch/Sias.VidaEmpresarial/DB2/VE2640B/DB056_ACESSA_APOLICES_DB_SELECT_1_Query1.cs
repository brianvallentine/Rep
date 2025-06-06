using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB056_ACESSA_APOLICES_DB_SELECT_1_Query1 : QueryBasis<DB056_ACESSA_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_EMISSOR
            INTO :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :PARGEREM-NUM-APOLICE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT RAMO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.PARGEREM_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string PARGEREM_NUM_APOLICE { get; set; }

        public static DB056_ACESSA_APOLICES_DB_SELECT_1_Query1 Execute(DB056_ACESSA_APOLICES_DB_SELECT_1_Query1 dB056_ACESSA_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = dB056_ACESSA_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB056_ACESSA_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB056_ACESSA_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}