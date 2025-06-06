using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_EMISSOR
            INTO :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1 r2150_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r2150_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}