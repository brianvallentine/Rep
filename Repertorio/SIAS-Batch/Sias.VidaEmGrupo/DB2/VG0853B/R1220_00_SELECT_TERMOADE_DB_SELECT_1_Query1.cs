using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1 : QueryBasis<R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_ADESAO
            INTO :TERMOADE-DATA-ADESAO
            FROM SEGUROS.TERMO_ADESAO
            WHERE NUM_TERMO = :TERMOADE-NUM-TERMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_ADESAO
											FROM SEGUROS.TERMO_ADESAO
											WHERE NUM_TERMO = '{this.TERMOADE_NUM_TERMO}'";

            return query;
        }
        public string TERMOADE_DATA_ADESAO { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

        public static R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1 Execute(R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1 r1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1)
        {
            var ths = r1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1();
            var i = 0;
            dta.TERMOADE_DATA_ADESAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}