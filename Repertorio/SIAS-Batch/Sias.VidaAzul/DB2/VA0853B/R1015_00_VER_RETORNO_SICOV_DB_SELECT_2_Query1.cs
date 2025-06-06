using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1 : QueryBasis<R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NSAS, 0)
            , VALUE(NSL, 0)
            , CAST(REPEAT( '0' , (6 - LENGTH(LTRIM(REPLACE(
            DIGITS(CODCONV), '0' , ' ' )))))
            || LTRIM(CHAR(CODCONV)) AS VARCHAR(6)) ||
            CAST(REPEAT( '0' , (6 - LENGTH(LTRIM(REPLACE(
            DIGITS(NSAS), '0' , ' ' ))))) ||
            LTRIM(CHAR(NSAS)) AS VARCHAR(6)) ||
            CAST(REPEAT( '0' , (9 - LENGTH(LTRIM(REPLACE(
            DIGITS(NSL), '0' , ' ' ))))) ||
            LTRIM(CHAR(NSL)) AS VARCHAR(9))
            INTO :V0HCTA-NSAS
            , :V0HCTA-NSL
            , :WS-COD-IDLG:VIND-IDLG
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0PROP-NRPARCEL
            AND SITUACAO IN ( '3' , 'A' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(NSAS
							, 0)
											, VALUE(NSL
							, 0)
											, CAST(REPEAT( '0' 
							, (6 - LENGTH(LTRIM(REPLACE(
											DIGITS(CODCONV)
							, '0' 
							, ' ' )))))
											|| LTRIM(CHAR(CODCONV)) AS VARCHAR(6)) ||
											CAST(REPEAT( '0' 
							, (6 - LENGTH(LTRIM(REPLACE(
											DIGITS(NSAS)
							, '0' 
							, ' ' ))))) ||
											LTRIM(CHAR(NSAS)) AS VARCHAR(6)) ||
											CAST(REPEAT( '0' 
							, (9 - LENGTH(LTRIM(REPLACE(
											DIGITS(NSL)
							, '0' 
							, ' ' ))))) ||
											LTRIM(CHAR(NSL)) AS VARCHAR(9))
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0PROP_NRPARCEL}'
											AND SITUACAO IN ( '3' 
							, 'A' )
											WITH UR";

            return query;
        }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }
        public string WS_COD_IDLG { get; set; }
        public string VIND_IDLG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1 Execute(R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1 r1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1)
        {
            var ths = r1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0HCTA_NSAS = result[i++].Value?.ToString();
            dta.V0HCTA_NSL = result[i++].Value?.ToString();
            dta.WS_COD_IDLG = result[i++].Value?.ToString();
            dta.VIND_IDLG = string.IsNullOrWhiteSpace(dta.WS_COD_IDLG) ? "-1" : "0";
            return dta;
        }

    }
}