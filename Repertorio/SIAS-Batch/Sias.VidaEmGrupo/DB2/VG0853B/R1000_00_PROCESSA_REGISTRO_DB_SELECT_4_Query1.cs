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
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIG_PRODU
            INTO :V0PRDVG-ORIG-PRODU
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND CODSUBES = :V0PROP-CODSUBES
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ORIG_PRODU
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND CODSUBES = '{this.V0PROP_CODSUBES}'";

            return query;
        }
        public string V0PRDVG_ORIG_PRODU { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0PRDVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}