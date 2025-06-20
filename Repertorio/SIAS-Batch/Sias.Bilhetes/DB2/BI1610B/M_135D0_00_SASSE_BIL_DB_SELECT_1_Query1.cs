using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1 : QueryBasis<M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_TP_MORA_IMOVEL
            INTO :GETPMOIM-DES-TP-MORA-IMOVEL
            FROM SEGUROS.GE_TP_MORAD_IMOVEL
            WHERE NUM_TP_MORA_IMOVEL = :GETPMOIM-NUM-TP-MORA-IMOVEL
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DES_TP_MORA_IMOVEL
											FROM SEGUROS.GE_TP_MORAD_IMOVEL
											WHERE NUM_TP_MORA_IMOVEL = '{this.GETPMOIM_NUM_TP_MORA_IMOVEL}'
											WITH UR";

            return query;
        }
        public string GETPMOIM_DES_TP_MORA_IMOVEL { get; set; }
        public string GETPMOIM_NUM_TP_MORA_IMOVEL { get; set; }

        public static M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1 Execute(M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1 m_135D0_00_SASSE_BIL_DB_SELECT_1_Query1)
        {
            var ths = m_135D0_00_SASSE_BIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_135D0_00_SASSE_BIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.GETPMOIM_DES_TP_MORA_IMOVEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}