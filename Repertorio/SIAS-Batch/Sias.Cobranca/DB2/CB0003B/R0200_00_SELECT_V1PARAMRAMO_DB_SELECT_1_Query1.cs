using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_VGAPC ,
            RAMO_VG ,
            RAMO_AP ,
            RAMO_SAUDE ,
            RAMO_EDUCACAO
            INTO :V1PARR-RAMO-VGAPC,
            :V1PARR-RAMO-VG ,
            :V1PARR-RAMO-AP ,
            :V1PARR-RAMO-SAUDE,
            :V1PARR-RAMO-EDUCA
            FROM SEGUROS.V1PARAMRAMO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VGAPC 
							,
											RAMO_VG 
							,
											RAMO_AP 
							,
											RAMO_SAUDE 
							,
											RAMO_EDUCACAO
											FROM SEGUROS.V1PARAMRAMO
											WITH UR";

            return query;
        }
        public string V1PARR_RAMO_VGAPC { get; set; }
        public string V1PARR_RAMO_VG { get; set; }
        public string V1PARR_RAMO_AP { get; set; }
        public string V1PARR_RAMO_SAUDE { get; set; }
        public string V1PARR_RAMO_EDUCA { get; set; }

        public static R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 r0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARR_RAMO_VGAPC = result[i++].Value?.ToString();
            dta.V1PARR_RAMO_VG = result[i++].Value?.ToString();
            dta.V1PARR_RAMO_AP = result[i++].Value?.ToString();
            dta.V1PARR_RAMO_SAUDE = result[i++].Value?.ToString();
            dta.V1PARR_RAMO_EDUCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}