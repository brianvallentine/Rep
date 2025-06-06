using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1 : QueryBasis<R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NRCERTIF
            INTO :V0PROP-NRCERTIF
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NUM_APOLICE = :V1SOLF-NUM-APOL
            AND A.CODSUBES = :V1SOLF-COD-SUBG
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            AND B.ORIG_PRODU IN
            ( 'EMPRE' , 'ESPEC' , 'ESPE1' , 'ESPE2' , 'ESPE3' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NRCERTIF
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'
											AND A.CODSUBES = '{this.V1SOLF_COD_SUBG}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES
											AND B.ORIG_PRODU IN
											( 'EMPRE' 
							, 'ESPEC' 
							, 'ESPE1' 
							, 'ESPE2' 
							, 'ESPE3' )";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }

        public static R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1 Execute(R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1 r0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1)
        {
            var ths = r0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0910_00_FETCH_V1SOLICFAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            return dta;
        }

    }
}