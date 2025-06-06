using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1 : QueryBasis<R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SEGURO,
            COD_CONV_CARTAO
            INTO :CONVEVG-COD-SEGURO,
            :CONVEVG-COD-CONV-CARTAO
            FROM SEGUROS.CONVENIOS_VG
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND CODSUBES = :PROPOVA-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SEGURO
							,
											COD_CONV_CARTAO
											FROM SEGUROS.CONVENIOS_VG
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPOVA_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string CONVEVG_COD_SEGURO { get; set; }
        public string CONVEVG_COD_CONV_CARTAO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1 Execute(R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1 r1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1)
        {
            var ths = r1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVEVG_COD_SEGURO = result[i++].Value?.ToString();
            dta.CONVEVG_COD_CONV_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}