using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class R0860_LER_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R0860_LER_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            RAMO_EMISSOR
            INTO
            :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R0860_LER_APOLICE_DB_SELECT_1_Query1 Execute(R0860_LER_APOLICE_DB_SELECT_1_Query1 r0860_LER_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r0860_LER_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0860_LER_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0860_LER_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}