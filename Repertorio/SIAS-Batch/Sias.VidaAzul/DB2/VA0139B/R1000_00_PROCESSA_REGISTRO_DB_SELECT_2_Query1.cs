using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODSUBES
            INTO :WHOST-CODSUBES
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE
            AND NRENDOS = 0
            AND DTTERVIG > :V0ENDO-DTINIVIG
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CODSUBES
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'
											AND NRENDOS = 0
											AND DTTERVIG > '{this.V0ENDO_DTINIVIG}'";

            return query;
        }
        public string WHOST_CODSUBES { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_CODSUBES = result[i++].Value?.ToString();
            return dta;
        }

    }
}