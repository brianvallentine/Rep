using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MODALIDADE
            INTO :APOLICES-COD-MODALIDADE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MODALIDADE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'";

            return query;
        }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1 r2230_00_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r2230_00_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}