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
    public class R2215_00_FETCH_COBER_DB_SELECT_1_Query1 : QueryBasis<R2215_00_FETCH_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_ACESSORIO
            INTO :WS-COBERTURA
            FROM SEGUROS.VG_ACESSORIO
            WHERE NUM_ACESSORIO = :VGCOBSUB-COD-COBERTURA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_ACESSORIO
											FROM SEGUROS.VG_ACESSORIO
											WHERE NUM_ACESSORIO = '{this.VGCOBSUB_COD_COBERTURA}'
											WITH UR";

            return query;
        }
        public string WS_COBERTURA { get; set; }
        public string VGCOBSUB_COD_COBERTURA { get; set; }

        public static R2215_00_FETCH_COBER_DB_SELECT_1_Query1 Execute(R2215_00_FETCH_COBER_DB_SELECT_1_Query1 r2215_00_FETCH_COBER_DB_SELECT_1_Query1)
        {
            var ths = r2215_00_FETCH_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2215_00_FETCH_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2215_00_FETCH_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}