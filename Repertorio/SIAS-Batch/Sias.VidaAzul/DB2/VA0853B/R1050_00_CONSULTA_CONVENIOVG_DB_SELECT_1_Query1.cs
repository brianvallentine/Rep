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
    public class R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 : QueryBasis<R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SEGURO,
            COD_CONV_CARTAO
            INTO :V0CONV-CODCONV,
            :V0CONV-CCRED
            FROM SEGUROS.V0CONVENIOSVG
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND CODSUBES = :V0PROP-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SEGURO
							,
											COD_CONV_CARTAO
											FROM SEGUROS.V0CONVENIOSVG
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND CODSUBES = '{this.V0PROP_CODSUBES}'
											WITH UR";

            return query;
        }
        public string V0CONV_CODCONV { get; set; }
        public string V0CONV_CCRED { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 Execute(R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 r1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CONV_CODCONV = result[i++].Value?.ToString();
            dta.V0CONV_CCRED = result[i++].Value?.ToString();
            return dta;
        }

    }
}