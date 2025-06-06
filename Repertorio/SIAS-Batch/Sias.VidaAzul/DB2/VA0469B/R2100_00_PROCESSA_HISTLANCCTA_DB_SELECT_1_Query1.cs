using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1 : QueryBasis<R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_NAOACEITE
            INTO :CONVEVG-COD-NAOACEITE
            FROM SEGUROS.CONVENIOS_VG
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            AND CODSUBES = :RELATORI-COD-SUBGRUPO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_NAOACEITE
											FROM SEGUROS.CONVENIOS_VG
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											AND CODSUBES = '{this.RELATORI_COD_SUBGRUPO}'";

            return query;
        }
        public string CONVEVG_COD_NAOACEITE { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1 Execute(R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1 r2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVEVG_COD_NAOACEITE = result[i++].Value?.ToString();
            return dta;
        }

    }
}